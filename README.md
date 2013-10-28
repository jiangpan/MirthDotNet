#MirthDotNet

MirthDotNet is a .NET library for the popular open source Mirth Connect HL7 interface
engine and server. This project aims to create a library to allow programatic access
to Mirth's features from a .NET project.

###Implementation

Mirth exposes Web Service endpoints for virtually all operations. The primary
Mirth UI (a downloadable Java Applet) makes use of this library to connect to the
server and send/receive data.

We will attempt to "clone" Mirth's client library in a way which makes sense for .NET
developers.

https://svn.mirthcorp.com/connect/trunk/server/src/com/mirth/connect/client/core/

This will involve

1. Cloning the class <code>com.mirth.connect.client.core.Client</code> and all public methods
2. Cloning the serializable data structures, many of which are located here: https://svn.mirthcorp.com/connect/trunk/server/src/com/mirth/connect/model/
