import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { Opskrift } from '../opskrift';

@Component({
  selector: 'app-forside',
  templateUrl: './forside.component.html',
  styleUrls: ['./forside.component.scss']
})
export class ForsideComponent implements OnInit {

  opskrifts: [];
  id: number;
  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.getAllOpskrift();
    this.opskriftId(this.id);
  }

  getAllOpskrift(): void {
    this.apiService.getOpskrift().subscribe((data: any) => {
      this.opskrifts = data;
    })
  }
  removeAllOpskrift(): void {
    this.apiService.deleteAllOpskrift().subscribe(() => {
      this.getAllOpskrift();
    })
  }
  opskriftId(id: number){
    this.router.navigate(['/opskrift', id]);
  }

}
