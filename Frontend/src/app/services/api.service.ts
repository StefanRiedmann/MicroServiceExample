import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

export interface Ms2Configuration
{
  url: string;
  secret: string;
}

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(public httpClient: HttpClient) { }

  async getConfiguration(): Promise<Ms2Configuration>
  {
    return new Promise<Ms2Configuration>((res,rej) => {
      this.httpClient.get<Ms2Configuration>('/api/getConfiguration').subscribe(
        response => res(response),
        reject => rej(reject)
      );
    })
  }

  async postConfiguration(url: string, secret: string)
  {
    let config: Ms2Configuration = {
      url: url,
      secret: secret
    };
    return new Promise<void>((res,rej) => {
      this.httpClient.post('/api/postConfiguration', config).subscribe(
        response => res(),
        reject => rej(reject)
      );
    })
  }

  async postMessage(msg: string): Promise<string>
  {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };
    return new Promise<string>((res,rej) => {
      this.httpClient.post<string>('/api/postMessage', JSON.stringify(msg), options).subscribe(
        response => res(response),
        err => 
        {
          if(err && err.status == 401)
          {
            rej(Error("Unauthorized"));
          }
          else if(err && err.error)
          {
            rej(Error(err.error));
          }
          rej("Error sending message");
        }
      );
    })
  }
}
