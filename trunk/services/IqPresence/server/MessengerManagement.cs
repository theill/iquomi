#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using log4net;

using XihSolutions.DotMSN;
using XihSolutions.DotMSN.Core;

using Commanigy.Iquomi.Services.IqAlerts;

#endregion

namespace Commanigy.Iquomi.Services.IqPresence {
	public class MessengerManagement {
		protected static readonly ILog log = LogManager.GetLogger(
			MethodBase.GetCurrentMethod().DeclaringType
			);

		private static readonly MessengerManagement instance = new MessengerManagement();

		private Messenger messenger;
		private Conversation conversation;

		private MessengerManagement() {
			messenger = new Messenger();

			// by default this example will emulate the official microsoft windows messenger client
			messenger.Credentials.ClientID = "msmsgs@msnmsgr.com";
			messenger.Credentials.ClientCode = "Q1P7W2E4J9R8U3S5";

			messenger.ConversationCreated += new ConversationCreatedEventHandler(messenger_ConversationCreated);
			messenger.Nameserver.SignedIn += new EventHandler(Nameserver_SignedIn);
			messenger.Nameserver.SignedOff += new SignedOffEventHandler(Nameserver_SignedOff);
			messenger.Nameserver.AuthenticationError += new HandlerExceptionEventHandler(Nameserver_AuthenticationError);
			messenger.Nameserver.ReverseAdded += new ContactChangedEventHandler(Nameserver_ReverseAdded);

			if (messenger.Connected) {
				SetStatus("Disconnecting from server");
				messenger.Disconnect();
			}

			messenger.Credentials.Account = "messenger@theill.com";
			messenger.Credentials.Password = "testpassword";
			SetStatus("Signing in...");
			messenger.Connect();
		}

		public static MessengerManagement Instance {
			get {
				return instance;
			}
		}

		public bool SendTextMessage(string puid, string message) {
			if (messenger == null || !messenger.Connected) {
				return false;
			}

			log.Debug("Creating conversation");
			Conversation ac = messenger.CreateConversation();

			log.Debug("Inviting user");
			ac.Invite(puid);

			log.Debug("Setting up contact joined handler");
			ac.Switchboard.TextMessageReceived += new TextMessageReceivedEventHandler(Switchboard_TextMessageReceived);
			ac.Switchboard.ContactJoined += new ContactChangedEventHandler(Switchboard_ContactJoined);
			ac.Switchboard.ContactLeft += new ContactChangedEventHandler(Switchboard_ContactLeft);

			System.Threading.Thread.Sleep(1000);

			log.Debug("Checking switchboard processor");
			if (!ac.SwitchboardProcessor.Connected) {
				log.Debug("Request new switchboard");
				ac.Messenger.Nameserver.RequestSwitchboard(ac.Switchboard, this);
			}

			log.Debug("Creating message");
			TextMessage m = new TextMessage(message);

			log.Debug("Sending text messsage");
			ac.Switchboard.SendTextMessage(m);

			System.Threading.Thread.Sleep(1000);

			return true;
		}

		void Nameserver_ReverseAdded(object sender, ContactEventArgs e) {
			SetStatus("Reverse added -> adding to personal list");
			messenger.Nameserver.AddContactToList(e.Contact, MSNLists.AllowedList);
			SetStatus("Added to personal list");
		}

		void Nameserver_AuthenticationError(object sender, ExceptionEventArgs e) {
			SetStatus("Authentication failed");
		}

		void Nameserver_SignedOff(object sender, SignedOffEventArgs e) {
			SetStatus("Signed off from the messenger network");

			messenger.Owner.Status = PresenceStatus.Offline;
		}

		void Nameserver_SignedIn(object sender, EventArgs e) {
			SetStatus("Signed into the messenger network as " + messenger.Owner.Name);

			messenger.Owner.Name = "Iquomi";
			messenger.Owner.Status = PresenceStatus.Online;

			//foreach (Contact e in messenger.ContactList.Reverse) {
			//    if (DbAccount.FindByEmail(e.Mail) != null) {
			//        messenger.Nameserver.AddContactToList(e.Contact, MSNLists.AllowedList);
			//    }
			//}

			//foreach (Contact contact in messenger.ContactList.All) {
			//    SetStatus(contact.Name);
			//}
		}

		private Conversation CreateConversationForm(Conversation conversation) {
			this.conversation = conversation;
			conversation.Messenger.TransferInvitationReceived += new XihSolutions.DotMSN.DataTransfer.MSNSLPInvitationReceivedEventHandler(Messenger_TransferInvitationReceived);
			conversation.Switchboard.TextMessageReceived += new TextMessageReceivedEventHandler(Switchboard_TextMessageReceived);
			return conversation;
		}

		void Messenger_TransferInvitationReceived(object sender, XihSolutions.DotMSN.DataTransfer.MSNSLPInvitationEventArgs e) {
			//			e.TransferSession.DataStream = new FileStream("c:\\temp\\test.txt", FileMode.Create, FileAccess.Write);
			e.Accept = true;
		}

		void Switchboard_TextMessageReceived(object sender, TextMessageEventArgs e) {
			SetStatus("< " + e.Message.Text);
			TextMessage message = new TextMessage("Thanks for " + e.Message.Text);
			conversation.Switchboard.SendTextMessage(message);
			SetStatus("> " + message.Text);
		}

		void messenger_ConversationCreated(object sender, ConversationCreatedEventArgs e) {
			if (e.Initiator == null) {
				this.conversation = e.Conversation;
				conversation.Messenger.TransferInvitationReceived += new XihSolutions.DotMSN.DataTransfer.MSNSLPInvitationReceivedEventHandler(Messenger_TransferInvitationReceived);
				conversation.Switchboard.TextMessageReceived += new TextMessageReceivedEventHandler(Switchboard_TextMessageReceived);
				// use the invoke method to create the form in the main thread
				//				this.Invoke(new CreateConversationDelegate(CreateConversationForm), new object[] { e.Conversation });
			}
			else if (e.Initiator == this.messenger) {
				log.Debug("Conversation created");
//				e.Conversation.Switchboard.SendTextMessage(new TextMessage("asdf"));
			}
		}

		private void Switchboard_ContactJoined(object sender, ContactEventArgs e) {
			log.Debug("* " + e.Contact.Name + " joined the conversation");
		}

		private void Switchboard_ContactLeft(object sender, ContactEventArgs e) {
			log.Debug("* " + e.Contact.Name + " left the conversation");
		}

		private delegate Conversation CreateConversationDelegate(Conversation conversation);
		private delegate void SetStatusDelegate(string status);

		private void SetStatusSynchronized(string status) {
			log.Debug(status);
		}

		private void SetStatus(string status) {
			log.Debug(status);
		}

	}
}
