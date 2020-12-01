# CllientSignalR
SignalR used to connect the client with the Hub.

I have created an application that does not require hard refresh to see the updated value from the Database to the UI Dashboard.

API
Create a API for signalR Hub , I have used APS.NET WEB API 2 and installed Owin startup as my starup class

Next create a Hub where the client will connect to the server, here is the code for the hub

![](demo/MessageHubAPI.png)

Here is the Demo of the project
![](demo/SignarDemo.gif)


Refrences:
https://stackoverflow.com/questions/41378582/angular-2-typescript-using-signalr
https://stackoverflow.com/questions/54297637/how-to-hook-up-signalr-with-an-angular-7-application
https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/hubs-api-guide-javascript-client
https://www.zealousweb.com/calling-rest-api-from-sql-server-stored-procedure/
