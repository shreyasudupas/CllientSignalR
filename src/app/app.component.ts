import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  
  title = 'angSingalR';

  ngOnInit() {
    $(document).ready(function() {
         alert('we call alert from JQuery');
    });
 }
}
