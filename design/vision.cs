	
	// 
	// Client:
	// Bookmark service where the service is firstly located and then the
	// bookmarks are managed by creading, reading updating and deleting.
	//
	
	// look up service based on (unique) name
	IService bookmarkService = Iquomi.getInstance().getServiceRepository().get("MyBookmarkService");
	
	// authenticate to use with std. username/password
	AuthenticatedService service = bookmarkService.authenticate("peter@theill.com", "4F3A74704073");
	
	// build unique token
	string token = IquomiServiceUtility.generateToken();
	
	// token now contains "{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}"
	
	// create new item with unique id
	Item aBookmark = new Item();
	aBookmark.StoreId = token;
	
	// the "Bookmark" class is a custom developed class for storing the 
	// necessary information on the remote service
	aBookmark.StoreObject = new Bookmark("Microsoft", "http://www.microsoft.com/");
	service.create(nsBookmark);
	
	// do custom lookup for element
	Item a = new Item();
	a.StorePath = "//[StoreId='{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}']";
	Item b = (Item)service.read(a);
	
	// setup notify event when item is updated
	b.addNotification(new Notification(NotificationType.UPDATE, null));
	service.update(b);
	
	// update existing element
	Bookmark bookmark = (Bookmark)b.deserialize(typeof(Bookmark));
	bookmark.Description = "The Microsoft web site contains vast info...";
	
	// this updates the element *and* triggers an "update" event
	bookmark = service.update(b);
	
	// delete element with unique store id
	Item c = new Item();
	c.StoreId = "{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}";
	bool ok = service.delete(c);
	
	// get all instances matching custom lookup
	Item d = new Item();
	d.StorePath = "//";
	Item[] e = (Item[])service.readAll(d);
	
	// find element directly based on unique element
	Item e = new Item();
	e.StoreId = "{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}";
	e = (Item)service.read(e);
	
	
	//
	// Server:
	// Example *generic* implementation of a Bookmark service
	//
	// TODO: Apply "charge" calls on Item objects either by using a proxy
	// class or by directly putting this into code such as return charge(
	// Item[]). However it should be considered how to easily log a charge
	// for custom classes thus a given server side implementator doesn't
	// need to explicitly execute the 'charge' method.
	// 
	// .NET classes: XmlDocument
	//
	
	public class MyBookmarkService: AuthenticatedService {
		public Item[] readAll(Item d) {
			XmlDocument bm = new XmlDocument();
			bm.Load("bookmarks.xml");
			XmlNodeList list = bm.DocumentElement.SelectNodes(d.StorePath);
			
			// [!] this doesn't work. serverside *generic* service shouldn't 
			// depend on any client service objects (such as "Bookmark"). If
			// it does a specific service should be deployed on the server
			// including assemblies with proper class definitions
			ArrayList bmlist = new ArrayList();
			foreach (XmlNode n in list) {
				Item x = new Item();
				
				x.serialize(n.OuterXml);
				bmlist.Add();
			}
			
			return (Item[])bmlist.ToArray();
		}
	}
	
	/*
	
	The <Bookmark> element is an element unknown to the server-side service
	and is merely an (xml-)serialized version of the object.
	
	<Service name="MyBookmarkService">
		<Store>
			<Name>Bookmarks</Name>
			<Description>My bookmarks</Description>
			<Items>
				<Item>
					<StoreId>{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}</StoreId>
					<StoreObject>
						<Bookmark>												}
							<Title>Microsoft</Title>							}
							<Description />										} not known for 
							<Url>http://www.microsoft.com/</Url>				}  generic service
						</Bookmark>												}
					</StoreObject>
				</Item>
				<Item>
					<StoreId>{A509B1A8-37EF-4b3f-8CFC-4FAA74704073}</StoreId>
					<StoreObject>
						<Bookmark>
							<Title>Oracle</Title>
							<Description />
							<Url>http://www.oracle.com/</Url>
						</Bookmark>
					</StoreObject>
				</Item>
			</Items>
		</Store>
	</Service>
	
	*/
	
	
	//
	// Client:
	// Sample implementation of a POP3 service
	//
	// Custom classes: User, Email
	// 
	
	IService pop3service = Iquomi.getInstance().getServiceRepository().get("Pop3Client");
	
	AuthenticatedService service = pop3service.authenticate("pt", "belle0");
	User user = service.read("/logon").deserialize(typeof(User));
	
	Form f = new Pop3LogonForm();
	f.logon(user.Username, user.Password);
	
	// looks up all emails stored under "/emails" node
	Item a = new Item();
	a.StorePath = "//emails";
	Item[] emails = (Item[])service.readAll(a);
	
	// iterate found emails doing autocasting from Item -> Message objects
	foreach (Message m in emails) {
		Console.WriteLine(m.Subject);
	}
	
	
	
	//
	// Server:
	// Sample implementation of a POP3 service
	// 
	// Custom classes:
	// .NET classes: TcpClient, NetworkStream, StreamWriter, StreamReader,
	// 		IIdentity, ArrayList
	// Todo: Check "IIdentity" interface for available methods/properties
	// References: http://www.ietf.org/rfc/rfc1939.txt
	//
	
	public class Pop3Client: AuthenticatedService {
		string hostname_;
		int port_;
		IIdentity identity_;
		
		public Pop3Client(IIdentity identity) {
			identity_ = identity;
		}
		
		// override
		public Item[] readAll(Item d) {
			
			// perform special processing when users does a readAll with 
			// '//emails' since we'll need to first lookup emails and place
			// these into the global store
			if (d.StorePath == "//emails") {
				
				// user wants to get a list of all available emails
				TcpClient client = new TcpClient(hostname_, port_);
				NetworkStream ns = client.GetStream();
				StreamWriter sw = new StreamWriter(ns);
				StreamReader sr = new StreamReader(ns);
				
				sw.WriteLine("USER {0}", identity_.Username);
				sw.Flush();
				
				string rsp = sr.ReadLine();
				if (rsp.Substring(0, 4) == "-ERR") {
					return null;
				}
				
				sw.WriteLine("PASS {0}", identity_.Password);
				sw.Flush();
				
				rsp = sr.ReadLine();
				
				// get number of new messages
				sw.WriteLine("STAT");
				sw.Flush();
				
				rsp = sr.ReadLine();
				int numMessages = Convert.ToInt16(rsp.Split(' ')[1]);
				if (numMessages == 0) {
					return null;
				}
				
				// fetch all messages and place in 'messages' structure
				ArrayList messages = new ArrayList();
				for (int i = 0; i < numMessages; i++) {
					sw.WriteLine("RETR {0}", i + 1);
					rsp = sr.ReadLine();
					if (rsp == ".") {
						break;
					}
					
					messages.Add(new Message(rsp));
				}
				
				// create message entries in repository and keep new items
				// so these can be returned to client
				ArrayList allMessages = new ArrayList();
				foreach (Message m in messages) {
					Item a = new Item();
					a.StorePath = "//emails";
					
					// serialize object to Xml and place in 'StoreObject' 
					// variable serialization is doing by using a "set" on 
					// a "StoreObject" property e.g. StoreObject { set {
					// StoreObject = serialize(value)} }
					a.StoreObject = m;
					
					allMessages.Add(this.create(a));
				}
				
				return (Item[])allMessages.ToArray();
			}
		}
	}
	
	
	
	
	
	//
	// Add "update" charge to bookmark service. if service is already activated
	// and in use by one or more users, the update takes place after fourteen
	// days. otherwise the service is scheduled to update immediately. In either
	// cases the service is activated.
	//
	// .NET classes: DateTime
	
	IService bookmarkService = Iquomi.getInstance().getServiceRepository().get("MyBookmarkService");
	
	AuthorizedService service = bookmarkService.authorize("admin", "secret");
	
	// get model and add an update charge of 0.15 EUR for entire service
	LicensingModel model = service.getLicensingModel();
	Charge charge = new Charge();
	charge.Type = ChargeType.UPDATE;
	charge.Price = 0.15;
	charge.Unit = ChargeUnit.EUR;
	model.addCharge(charge);
	
	// update service immediately unless it's in use; in that case way two
	// weeks before doing so. [TODO] notify users in protocol (how?)
	service.scheduleUpdate(
		(aservice.isActive() && aservice.isUsed()) ?
		System.DateTime.Now.AddDays(14) :
		System.DateTime.Now
	);
	
	// activate if not already activated
	service.activate();
	
	
	//
	// Charges can be applied directly on items as well so it's possible
	// to e.g. set a price when updating a specific item.
	// 
	
	Item a = new Item();
	a.StoreId = "A509B1A8-37EF-4b3f-8CFC-4F3A74704073";
	a = (Item)service.read(a);
	
	Charge charge = new Charge();
	charge.Type = ChargeType.UPDATE;
	charge.Price = 0.05;
	charge.Unit = ChargeUnit.EUR;
	
	LicensingModel model = a.getLicensingModel();
	model.addCharge(charge);
	
	
	//
	// Services can determine which (Iquomi-enabled) servers they'll use 
	// for communication. This feature can be used for corporations using
	// Iquomi for internal purposes where they need to distribute their
	// data over a predefined number of internal servers.
	//
	
	DataLayer dl = authenticatedService.getDataLayer();
	dl.setPeerGroup(
		new PeerGroup(
			"Corporate Data Store",
			new Peer[] = {
				new Peer("192.168.0.100"),
				new Peer("192.168.0.101"),
				new Peer("192.168.0.102")
			}
		)
	);
	
	

	//
	// Work in progress ...
	//
	//


	IService iservice = Iquomi.getInstance().getServiceRepository().get("Newsletter");
	AuthorizedService service = iservice.authorize("admin", "secret");
	
	// initially setup an update event when '//letters' branch is updated
	Item letters = service.read("//letters");
	letters.addNotification(new Notification(NotificationType.UPDATE, null));
	
	// create a new newsletter
	Item letter = new Item();
	letter.StorePath = "//letters";
	letter.StoreObject = "<letter><subject>Good product</subject><text>Buy my product.</text></letter>";
	letter = service.create(letter);

	// subscribers are added like this
	Item subscriber = new Item();
	subscriber.StorePath = "//subscribers";
	subscriber.StoreObject = "<subscriber><name>Peter Theill</name><email>peter@theill.com</email></subscriber>";
	subscriber = service.create(subscriber);
	
	// setup listeners to act on updates to letters
	ActionListener dispatch = new ActionListener();
	dispatch.Source = letters;
	dispatch.Action = Notify("//subscribers/subscriber/email", "//letters/letter/text");
	
	subscriber.addListener(dispatch);
	
	
	//
	// -- Class hierarchy --
	//
	
	public class Iquomi {
		public static void Iquomi getInstance();
		public IServiceRepository getServiceRepository();
		
		private Iquomi();
	}
	
	public interface IServiceRepository {
		// locate service with unique name
		public IService get(string name);
	}
	
	public interface IService {
		public Item create(Item i);
		public Item read(Item i);
		public Item read(string storeId);
		public Item update(Item i);
		public bool delete(Item i);
		public Item[] readAll(Item i);
	}
	
	public class Service: IService {
		// create new item in store
		public Item create(Item i);
		
		// get existing item from store matching criteria
		public Item read(Item i);
		public Item read(string s);
		
		// update existing item in store
		public Item update(Item i);
		
		// delete existing item from store
		public bool delete(Item i);
		
		// get all items from store matching criteria
		public Item[] readAll(Item i);
		
		// authenticate user to service
		public AuthenticateService authenticate(System.Security.Principal.IIdentity identity);
		
		// authorize user to service
		public AuthorizationService authorize(System.Security.Principal.IIdentity identity);
	}
	
	public class AuthenticatedService: Service {
		public Item charge(Item i);
		public Item[] charge(Item[] items);
	}
	
	public class AuthorizedService: Service {
		// get attached licensing model for setting up specific charges
		public LicensingModel getLicensingModel();
		
		// activate service (put into production)
		public bool activate();
		
		// deactivate service
		public bool deactivate();
		
		// update service on specific time
		public bool scheduleUpdate(System.DateTime);
		
		// check if service is currently activated
		public bool isActive();
		
		// check if service is currently used by one or more accounts
		public bool isUsed();
	}
	
	public class LicensingModel {
		// manage charges on model
		public void addCharge(Charge);
		public void removeCharge(Charge);
		
		// get all charges available for model
		public Charge[] getCharges();
	}
	
	public class Charge {
		public ChargeType Type;
		public float Price;
		public ChargeUnit Unit;
	}
	
	public class Item: System.Collections.IEnumerable {
		// store unique id (i.e. for specific service/user)
		public string StoreId;
		
		// unique xpath to element (or used when creating subelements)
		public string StorePath;
		
		// Xml serialized object
		public string StoreObject;
		
		// notifications can attach to any object stored in the store
		public void addNotification(Notification n);
		public void removeNotification(Notification n);

//		public void addListener(Item i);
//		public void removeListener(Item i);
		
		// licensing models can be setup for specific items
		public LicensingModel getLicensingModel();
		
		// (de)serialize from/to Xml
		public void serialize(string);
		public object deserialize(typeof(object));
	}
	
	public class Notification {
		NotificationType Type;
		Action Action;
		
		public Notification(NotificationType type, Action action);
	}
	
	public class Action {
		ActionType Type;
		string Code;
	}
	
	public class DataLayer {
		public PeerGroup getPeerGroup();
		public void setPeerGroup(PeerGroup);
	}
	
	public class PeerGroup {
		public string Name;
		public Peer[] getPeers();
	}
	
	public class Peer {
		public string Ip;
	}
	
	// types of charge e.g. "charge per read"
	enum ChargeType {
		NONE = 0,
		CREATE = 1,
		READ = 2,
		UPDATE = 3,
		DELETE = 4,
		TRANSFER = 5,
		...
	}
	
	// currency (or something else?) unit for charge
	enum ChargeUnit {
		EUR = "EUR",
		USD = "USD",
		DKK = "DKK",
		...
	}
	
	// types of notifications e.g. "notify on update"
	enum NotificationType {
		READ = 0,
		UPDATE = 1,
		DELETE = 2
	}
	
	enum ActionType {
		SCRIPT = 0,
		HTTP_POST = 1,
		HTTP_GET = 2
	}
