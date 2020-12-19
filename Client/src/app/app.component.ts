import { Component, NgZone, OnInit } from '@angular/core';
import { DataServiceService } from '../app/data-service.service';
declare var $: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  
  title = 'angSingalR';
  tableData:any;
  messageFromServer:string;
  connectionId;
  connection:any;
  MessageHubProxy:any;
  
  constructor(private service:DataServiceService,private _zone:NgZone){

  }

  ngOnInit() {

    var type = this;
    $(document).ready(function() {
      //alert('I am Called From jQuery');
    });

    var serverUrl  = "http://localhost:61525/signalr";
    //Establish the connection to the hub
    type.connection = $.hubConnection(serverUrl);
    
    type.MessageHubProxy = type.connection.createHubProxy('MessageHub');
    //Send message from Server
    type.MessageHubProxy.on('updateMessage', function(messages:any) {
          console.log("Hit sucessfull");

          type.refreshData(messages);

    });

    //Message from 2nd Hub method 
    type.MessageHubProxy.on('reciveMessage', function(message:any) {
      console.log("Hit sucessfull");

      type._zone.run(()=>{
        type.messageFromServer = message;
      })
    });

    // connection.start()
    //   .done(function(){ 
    //     console.log('Now connected, connection ID=' + connection.id); 
    //     type.connectionId = connection.id;
    //   })
    //   .fail(function(){ console.log('Could not connect'); });
    type.connection.start()
      .done(function(){ 
        console.log('Now connected, connection ID=' + type.connection.id); 
        type.connectionId = type.connection.id;
      })
      .fail(function(){ console.log('Could not connect'); });

      //Get the table from the API
      this.service.getAllMessage().subscribe(data=>{
        this.tableData = data;
      },err=>console.log(err));

    

 }

  refreshData(message:any){
   this._zone.run(()=>{
      this.tableData = message;
   });
   
 }

 callServerMethod(){

    //invoking the hub method from client
    this.MessageHubProxy.invoke('recieveMessage',this.connectionId).done(function(){
      console.log ('Invocation of recieveMessage succeeded');
    }).fail(function(error){
      console.log('Invocation of recieveMessage failed. Error: ' + error);
    });
 }

}
