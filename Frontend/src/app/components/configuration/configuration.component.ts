import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-configuration',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.scss']
})
export class ConfigurationComponent implements OnInit
{
  busy: boolean;
  url: string;
  secret: string;


  constructor(private apiService: ApiService)
  {
    apiService.getConfiguration()
  }

  async ngOnInit()
  {
    this.busy = true;
    try
    {
      var config = await this.apiService.getConfiguration();
      console.log(config);
      this.url = config.url;
      this.secret = config.secret;
    }
    catch(err)
    {
      console.log(err);
      alert("Error loading config");
    }
    this.busy = false;
  }

  async saveConfig()
  {
    if(this.busy)
    {
      return;
    }
    this.busy = true;
    try
    {
      await this.apiService.postConfiguration(this.url, this.secret);
    }
    catch(err)
    {
      console.log(err);
      alert("Error saving config");
    }
    this.busy = false;
  }
}
