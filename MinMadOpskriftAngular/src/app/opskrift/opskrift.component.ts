import { Opskrift } from './../opskrift';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-opskrift',
  templateUrl: './opskrift.component.html',
  styleUrls: ['./opskrift.component.scss']
})
export class OpskriftComponent implements OnInit {

  id: number;
  opskrift: Opskrift;

  currentOpskrift = null;
  constructor(private apiService: ApiService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    
    this.id = this.route.snapshot.paramMap.get['id'];
    this.apiService.getOpskriftById(this.id).subscribe(data => {
      this.opskrift = data;
    }, error => console.log(error));
  }

  getOpskrift(): void {
    
  }
}
