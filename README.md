# SignalR used in angular to get updated data from database (without Refresh).
SignalR used to connect the client with the Hub.

I have created an application that does not require hard refresh to see the updated value from the Database to the UI Dashboard.

Here is the Demo of the project

![](demo/SignarDemo.gif)

  <p>
  <b>Steps to recreate the above project</b>  
  </p>
  <div>
  <b><h4>API Methods</h4><b>
    <p> Create a API for signalR Hub , I have used APS.NET WEB API 2 and installed Owin startup as my starup class</p>
     <p>Next create a Hub where the client will connect to the server, here is the code for the hub</p>
  </div>
  
  ![](demo/MessageHubAPI.png)
<br/>

<p>Here <b>SendMessage</b> in the Hub method that will be accessed by controller inorder to push the data to the client , but <b>updateMessage</b> is the message that is method is accessed by the client <b>(dont get confused)</b>.<p/>

<p>Next enable cors in signalR in Startup class or else signalR client will not be able to connect to this API </p>

![](demo/MessageHubStartup.png)

<p>Next, I have written a Trigger that inturn calls the APIs when there is a update in the database as shown below</p>

![](demo/SPCallAPI.png)

<p>API will push the data to all the client connected to the hub as shown below : calls the hubMethod which inturn push the data to updatemessage method</p>

![](demo/ControllerPushDatatoClient.png)

<p><h3> Angular Client</h3></p>
<p> In this I have used Jquery signalR and installed all required packages. 
  Steps to follow:
  <ul>
    <li>Create a Hub Connection ->  $.hubConnection(serverUrl); </li>
    <li>Connect to the hub method -> connection.createHubProxy('MessageHub');</li>
    <li>Connect the hub -> connection.start()</li>
    <li>Next when the hub pushes the data from the server use this function -> contosoChatHubProxy.on('updateMessage', function(messages:any)</li>
  </ul></p>

  <p>Once all this is done run API and angular client first the client will connect to the API Hub once the connection is established then only data can be pushed to the server.</p>


<b>Refrences:</b><br/>
https://stackoverflow.com/questions/41378582/angular-2-typescript-using-signalr
https://stackoverflow.com/questions/54297637/how-to-hook-up-signalr-with-an-angular-7-application
https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/hubs-api-guide-javascript-client
https://www.zealousweb.com/calling-rest-api-from-sql-server-stored-procedure/
