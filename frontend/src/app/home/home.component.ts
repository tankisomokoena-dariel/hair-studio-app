import { Component, Type } from '@angular/core';
import { HomeService } from '../services/home.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CookieService } from 'ngx-cookie-service';

/*********************************************************************************************************/
/****************************************  Modal Starts Here  ********************************************/


@Component({
	selector: 'ngbd-modal-confirm',
	standalone: true,
	template: `
		<div class="modal-header">
			<h4 class="modal-title" id="modal-title">{{requestedService.svcName}}</h4>
			<button
				type="button"
				class="btn-close"
				aria-describedby="modal-title"
				(click)="modal.dismiss('Cross click')"
			></button>
		</div>
		<div class="modal-body">
			<strong>Description:</strong> <p>{{requestedService.svcDescription}}</p>
			<strong>ETA:</strong> <p>{{requestedService.svcETA}}</p>
			<strong>Price:</strong> <p>R {{requestedService.svcPrice}}</p>
			<div class="modal-img">
				<img style="position: relative; width: 20rem; height: 23rem;" [src] = "requestedService.imgURL"/>
			</div>
			
		</div>
		<div class="modal-footer">
			<button type="button" class="btn btn-outline-secondary" (click)="modal.dismiss('cancel click')">Cancel</button>
			<button type="button" class="btn btn-danger" routerLink="login" (click)="routeToLogin()" >Make Appointment</button>
		</div>
	`
})
export class NgbdModalConfirm {

	requestedService: any;

	constructor(public modal: NgbActiveModal, private studioServices: HomeService, private router: Router, private cookieService: CookieService) {}

	ngOnInit(){
		var svcId = this.cookieService.get('svcId');
			var id: number = parseInt(svcId); 
			this.requestedService = this.studioServices.getServiceById(id);
	}

	routeToLogin(){
		this.router.navigate(['/appointments']);
		this.modal.close();
	}
}

const MODALS: { [name: string]: Type<any> } = {
	focusFirst: NgbdModalConfirm
};


/*****************************************  Modal Ends Here  *********************************************/
/*********************************************************************************************************/


/*********************************************************************************************************/

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  readonly servicesRepository;
  
  constructor(private studioService: HomeService, private modalService: NgbModal, private cookieService: CookieService){
    this.servicesRepository = this.studioService.getAllServices();
  }

  open(name: string, id:number) {
		this.setServiceCookie(id);
		this.modalService.open(MODALS[name]);
	}

	setServiceCookie(value: number){
		this.cookieService.set('svcId', value.toString())
	}
}
