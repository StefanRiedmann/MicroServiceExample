import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

interface ChatMessage
{
  origin: 'user' | 'bot',
  message: string
}

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements AfterViewInit 
{
  @ViewChild('msg', {static: true}) msgElement: ElementRef;

  busy: boolean;
  currentMsg: string;
  messages: ChatMessage[] = [];

  constructor(private apiService: ApiService)
  {
    apiService.getConfiguration()
  }

  ngAfterViewInit() 
  {
    this.focusText();
    // this.currentMsg = "Remove Test Message";
    // this.sendMessage();
    
  }

  async sendMessage()
  {
    if(!this.currentMsg || this.busy)
    {
      return;
    }
    this.busy = true;
    try
    {
      const msg = this.currentMsg;
      const answer = await this.apiService.postMessage(this.currentMsg);
      this.messages.push({origin: 'user', message: msg});
      this.messages.push({origin: 'bot', message: answer});
      this.currentMsg = undefined;
      this.focusText();
    }
    catch(err)
    {
      alert(err.message);
      console.log(err);
    }
    this.busy = false;
  }

  private focusText()
  {
    if(this.msgElement)
    {
      this.msgElement.nativeElement.focus();
    }
  }

}
