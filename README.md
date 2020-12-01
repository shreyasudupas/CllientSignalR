# CllientSignalR
SignalR used to connect the client with the Hub.

I have created an application that does not require hard refresh to see the updated value from the Database to the UI Dashboard.

In database I have created a trigger that calls the API as soon as there is a change in column value. This API in turn pushes the data to the client though signalR hub.

Here is the Demo of the project
![](demo/SignarDemo.gif)


Refrences:
https://stackoverflow.com/questions/41378582/angular-2-typescript-using-signalr
https://stackoverflow.com/questions/54297637/how-to-hook-up-signalr-with-an-angular-7-application
https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/hubs-api-guide-javascript-client
https://www.zealousweb.com/calling-rest-api-from-sql-server-stored-procedure/
