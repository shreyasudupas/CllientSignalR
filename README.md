# CllientSignalR
SignalR used to connect the client with the Hub.

I have created an application that does not require hard refresh to see the updated value from the Database to the UI Dashboard.

In database I have created a trigger that calls the API as soon as there is a change in column value. This API in turn pushes the data to the client though signalR hub.
