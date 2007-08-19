Updates for Chapter 7
---------------------

The Serializer.startBody(""); line on page 184 should be changed to Serializer.startBody(null);. 
This is because passing an empty string as the encoding method does not work any more – a null value has to be passed to specify that we do not require any encoding. 
This is relevant throughout the SOAP body. The third parameter of any startElement() method from this point on should have null passed instead of an empty string.

The Serializer.startElement("contact", strMyContactsNamespace, "", "mc"); line on page 187, apart for the third parameter being changed to null like every other startElement() method, 
also needs a SoapAttribute() method inserting immediately after, as with the newer myContacts schema, it requires that a synchronize Boolean attribute is added to the element. 
Insert this line: 
Serializer.SoapAttribute("synchronize", null, "no", null); 

The surName element, also inserted on page 187, has changed to surname in the schema. 

In the MailStormClient application, you will need a test machine with possibly 256MB of memory as when testing was undergone here at Wrox, 
a 128MB PIII 450Mhz, the code would not execute as Windows was constantly swapping to disk. Alternatively, build and deploy the MailStormService on one machine, 
and the client on another. 
