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
  
  constructor(private service:DataServiceService,private _zone:NgZone){

  }

  ngOnInit() {

    var type = this;
    $(document).ready(function() {
      alert('I am Called From jQuery');
    });

    var serverUrl  = "http://localhost:61525/signalr";
    //Establish the connection to the hub
    var connection = $.hubConnection(serverUrl);
    var contosoChatHubProxy = connection.createHubProxy('MessageHub');
    contosoChatHubProxy.on('updateMessage', function(messages:any) {
          console.log("Hit sucessfull");

          type.refreshData(messages);

    });

    connection.start()
      .done(function(){ console.log('Now connected, connection ID=' + connection.id); })
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
}
