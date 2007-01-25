
 + provide base class for UserControls in order to add functions such as '_' to it
 
 + Proxy generated classes must be patched so they doesn't contain a namespace reference to "core" i.e.
   this code:
   
        [System.Xml.Serialization.XmlAttributeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core", DataType="nonNegativeInteger")]
		public string ChangeNumber {
            get {
                return this.changeNumberField;
            }
            set {
                this.changeNumberField = value;
            }
        }
   
    must be changed to:
    
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
		public string ChangeNumber {
            get {
                return this.changeNumberField;
            }
            set {
                this.changeNumberField = value;
            }
        }
    





Algorithm for the Life Game

For each cell in the array do the following: 
 Count the number of living neighbors of the cell.
 Determine the cell status in the next generation as follows: 
  If the count is 0, 1, 4, 5, 6, 7, or 8, then set the corresponding cell in another array called newmap to be dead.
  If the count is 3, then set the corresponding cell to be alive.
  If the count is 2, then set the corresponding cell to be the same as the cell in array map (since the status of a cell with count 2 does not change). 
 Copy the array newmap into the array map.
 Print the array map for the user. 
	
	
	
	//
	// generate note from a dataset
	//
	XmlDataDocument xmlDocument = new XmlDataDocument(dataSet1);
	foreach (XmlNode n in xmlDocument.ChildNodes[0].ChildNodes) {
		XmlElement element = (XmlElement)n;
		Note note = new Note();
		note.Title = element.GetElementsByTagName("title")[0].InnerText;
		note.Description = element.GetElementsByTagName("description")[0].InnerText;
		lbxNotes.Items.Add(note);
	}
	
	
	private void PrintValues(DataSet ds, string label){
		Console.WriteLine("\n" + label);
		foreach(DataTable t in ds.Tables){
			Console.WriteLine("TableName: " + t.TableName);
			foreach(DataRow r in t.Rows){
				foreach(DataColumn c in t.Columns){
					Console.Write("\t " + r[c] );
				}
				Console.WriteLine();
			}
		}
	}
	
	
	/// <summary>
	/// Generates XML Schema for Notes data.
	/// </summary>
	private void GenerateXSD() {
		
		dstNotes.Clear();
		dstNotes.DataSetName = "notes";
		
		DataTable note = dstNotes.Tables.Add("note");
		note.Columns.Add("title", typeof(string));
		note.Columns.Add("description", typeof(string));
		
		dstNotes.WriteXmlSchema("notes.xsd");
		
	}
	
	
	//
	// builds tree from xml document
	//
	tvNotes.Nodes.Clear();
	
	XmlDocument xml = new XmlDocument();
	xml.Load(reader);
	
	XmlNodeList nl = xml.DocumentElement.GetElementsByTagName("note");
	foreach(XmlNode n in nl) {
		XmlElement e = (XmlElement)((XmlElement)n);
		
		TreeNode tn = new NoteNode(
			e.GetElementsByTagName("title").Item(0).InnerText,
			e.GetElementsByTagName("description").Item(0).InnerText
		);
		tn.ImageIndex = 0;
		
		tvNotes.Nodes.Add(tn);
	}


	//
	// using reflection to load and execute a specific method
	//
	// find 'Show' method implemented since service needs to 
	// use a common interface
	MethodInfo serviceShowMethod = serviceType.GetMethod("Show");
	
	object serviceObj = serviceAssembly.CreateInstance(serviceType.FullName);
	serviceShowMethod.Invoke(serviceObj, null);
		
	MethodInfo mi = serviceType.GetMethod("xLoad");
	mi.Invoke(serviceObj, new object[] { (XmlReader)xml });





	WebRequest req = WebRequest.Create("http://localhost:89/contacts.xml");
	//			req.Method = "POST";
	//			req.ContentType = "text/xml";
	
	//			byte[] SomeBytes = Encoding.UTF8.GetBytes("et sjovt lille request".ToString());
	
	//			req.ContentLength = SomeBytes.Length;
	//			Stream newStream = req.GetRequestStream();
	//			newStream.Write(SomeBytes, 0, SomeBytes.Length);
	//			newStream.Close();
	
	WebResponse result = null;
	try {
		result = req.GetResponse();
		Stream ReceiveStream = result.GetResponseStream();
		Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
		StreamReader sr = new StreamReader( ReceiveStream, encode );
		
		XmlTextReader xml = new XmlTextReader(sr);
		FormatXml(xml);
		//				Console.WriteLine("\r\nResponse stream received");
		//				Char[] read = new Char[256];
		//				int count = sr.Read( read, 0, 256 );
		//				Console.WriteLine("HTML...\r\n");
		//				while (count > 0) {
		//					String str = new String(read, 0, count);
		//					Console.Write(str);
		//					count = sr.Read(read, 0, 256);
		//				}
		
		Console.ReadLine();
	}
	finally {
		if (result != null) {
			result.Close();
		}
	}
	
	
	//
	// Working with XML and DataSets
	//
	private void DemonstrateReadWriteXMLDocumentWithXMLReader(){
		// Create a DataSet with one table and two columns.
		DataSet OriginalDataSet = new DataSet("myDataSet");
		OriginalDataSet.Namespace= "NetFrameWork";
		DataTable myTable = new DataTable("myTable");
		DataColumn c1 = new DataColumn("id", Type.GetType("System.Int32"));
		c1.AutoIncrement= true;
		DataColumn c2 = new DataColumn("item");
		myTable.Columns.Add(c1);
		myTable.Columns.Add(c2);
		OriginalDataSet.Tables.Add(myTable);
		// Add ten rows.
		DataRow newRow;
		for(int i = 0; i < 10; i++){
			newRow = myTable.NewRow();
			newRow["item"]= "item " + i;
			myTable.Rows.Add(newRow);
		}
		OriginalDataSet.AcceptChanges();
		// Print out values of each table in the DataSet using the 
		// function defined below.
		PrintValues(OriginalDataSet, "Original DataSet");
		// Write the XML schema and data to file with FileStream.
		string xmlFilename = "myXmlDocument.xml";
		// Create FileStream    
		System.IO.FileStream fsWriteXml = new System.IO.FileStream
			(xmlFilename, System.IO.FileMode.Create);
		// Create an XmlTextWriter to write the file.
		System.Xml.XmlTextWriter xmlWriter = new System.Xml.XmlTextWriter
			(fsWriteXml, System.Text.Encoding.Unicode);
		// Use WriteXml to write the document.
		OriginalDataSet.WriteXml(xmlWriter);
		// Close the FileStream.
		fsWriteXml.Close();
		
		// Dispose of the original DataSet.
		OriginalDataSet.Dispose();
		// Create a new DataSet.
		DataSet newDataSet = new DataSet("New DataSet");
		
		// Read the XML document back in. 
		// Create new FileStream to read schema with.
		System.IO.FileStream fsReadXml = new System.IO.FileStream
			(xmlFilename, System.IO.FileMode.Open);
		// Create an XmlTextReader to read the file.
		System.Xml.XmlTextReader myXmlReader = 
			new System.Xml.XmlTextReader(fsReadXml);
		
		// Read the XML document into the DataSet.
		newDataSet.ReadXml(myXmlReader);
		// Close the XmlTextReader
		myXmlReader.Close();
		
		// Print out values of each table in the DataSet using the 
		// function defined below.
		PrintValues(newDataSet,"New DataSet");
	}



	//
	// XML formatting utility methods
	//

	private static void FormatXml (XmlReader reader) {
		int piCount=0, docCount=0, commentCount=0, elementCount=0, attributeCount=0, textCount=0, whitespaceCount=0;

		while (reader.Read()) {
			switch (reader.NodeType) {
				case XmlNodeType.ProcessingInstruction:
					Format (reader, "ProcessingInstruction");
					piCount++;
					break;
				case XmlNodeType.DocumentType:
					Format (reader, "DocumentType");
					docCount++;
					break;
				case XmlNodeType.Comment:
					Format (reader, "Comment");
					commentCount++;
					break;
				case XmlNodeType.Element:
					Format (reader, "Element");
					while(reader.MoveToNextAttribute()) {
						Format (reader, "Attribute");
					}
					elementCount++;
					if (reader.HasAttributes)
						attributeCount += reader.AttributeCount;
					break;
				case XmlNodeType.Text:
					Format (reader, "Text");
					textCount++;
					break;
				case XmlNodeType.Whitespace:
					whitespaceCount++;
					break;
			}
		}
		
		// Display the Statistics
		Console.WriteLine ();
		Console.WriteLine("Statistics for stream");
		Console.WriteLine ();
		Console.WriteLine("ProcessingInstruction: {0}",piCount++);
		Console.WriteLine("DocumentType: {0}",docCount++);
		Console.WriteLine("Comment: {0}",commentCount++);
		Console.WriteLine("Element: {0}",elementCount++);
		Console.WriteLine("Attribute: {0}",attributeCount++);
		Console.WriteLine("Text: {0}",textCount++);
		Console.WriteLine("Whitespace: {0}",whitespaceCount++);
	}
	
	
	// Format the output
	private static void Format(XmlReader reader, String nodeType) {
		// Format the output
		Console.Write(reader.Depth + " ");
		Console.Write(reader.AttributeCount + " ");
		for (int i=0; i < reader.Depth; i++) {
			Console.Write('\t');
		}
		
		Console.Write(nodeType + "<" + reader.Name + ">" + reader.Value);
		Console.WriteLine();
	}






Keywords for use with Visual Source Safe:

$Archive: /iquomi.root/Iquomi/readme.txt $              VSS archive file location 
$Author: Pt $               User who last changed the file 
$Date: 5/22/05 8:54p $                 Date and time of last checkin 
$Header: /iquomi.root/Iquomi/readme.txt 1     5/22/05 8:54p Pt $               Logfile, Revision, Date,Author 
$History: readme.txt $              File history, VSS format 
 * 
 * *****************  Version 1  *****************
 * User: Pt           Date: 5/22/05    Time: 8:54p
 * Created in $/iquomi.root/Iquomi
$JustDate:  5/22/05 $             Date, without the time addendum. 
$Log: /iquomi.root/Iquomi/readme.txt $                  File history, RCS format 
 * 
 * 1     5/22/05 8:54p Pt
$Logfile: /iquomi.root/Iquomi/readme.txt $              Same as Archive 
$Modtime: 1/02/05 11:41p $              Date and time of last modification 
$Revision: 1 $             VSS version number 
$Workfile: readme.txt $             File name 
$NoKeywords: $           No keyword expansion for all keywords that follow  