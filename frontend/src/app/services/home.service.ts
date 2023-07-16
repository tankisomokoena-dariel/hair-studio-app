import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor() { }

  private readonly servicesRepository = [ 	
    {	
      svcId: 1,
      svcName: 'Fade + Line',
      svcDescription: 'Normal fade with a line',
      svcETA: '35 minutes' ,
      svcPrice: 200.00,
      imgURL:'https://i0.wp.com/therighthairstyles.com/wp-content/uploads/2021/09/1-the-ivy-league-mens-cut.jpg?resize=500%2C592'
    },
                {	
      svcId: 2, 
      svcName: 'Fade',
      svcDescription: 'Just a fade with no styling',
      svcETA: '30 minutes',
      svcPrice: 180.00,
      imgURL:'https://cdn.shopify.com/s/files/1/0125/0833/2091/files/Best_men_s_hairstyles_for_a_clean_shaven_face_-_xbigwesx_large.png?v=1562364097'
    },
                {
      svcId: 3, 
      svcName: 'Fade + Waves',
      svcDescription: 'Medium-spiked fade on a faux hawk',
      svcETA: '60 minutes',
      svcPrice: 350.00,
      imgURL:'https://content.latest-hairstyles.com/wp-content/uploads/medium-spiked-fade-on-a-faux-hawk-haircut.jpg'
    },
      {
      svcId: 4, 
      svcName: 'Fade + Curls',
      svcDescription: 'Normal fade with curled hair',
      svcETA: '45 minutes',
      svcPrice: 270.00,
      imgURL:'https://content.latest-hairstyles.com/wp-content/uploads/thick-mid-fade-for-men.jpg'
    },
      {
      svcId: 5, 
      svcName: 'Fade + Roll ',
      svcDescription: 'Normal fade. The hair gets rolled with a sponge',
      svcETA: '40 minutes',
      svcPrice: 230.00,
      imgURL:'https://cdn.shopify.com/s/files/1/0125/0833/2091/files/Best_men_s_hairstyles_for_a_clean_shaven_face_-_jmdabarber_large.png?v=1562363355'
    },
      {
      svcId: 6, 
      svcName: 'Fade + Ponytail ',
      svcDescription: 'Hair relaxer is used.',
      svcETA: '45 minutes',
      svcPrice: 250.00,
      imgURL:'https://cdn.shopify.com/s/files/1/0125/0833/2091/files/Best_men_s_hairstyles_for_a_clean_shaven_face_-_brandonjlarge_large.png?v=1562364546'
    },
      {	
      svcId: 7, 
      svcName: 'Brush',
      svcDescription: 'Fine Haircut + Trim',
      svcETA: '20 minutes',
      svcPrice: 120.00,
      imgURL:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSYNm6cTKY0lUlgYmY3BJ6tb1nSvM4x_aFW6w&usqp=CAU'
    },
      {
      svcId: 8, 
      svcName: 'Bald',
      svcDescription: 'Get all hair removed.',
      svcETA: '20 minutes',
      svcPrice: 100.00,
      imgURL:'https://www.newtimeshair.com/wp-content/uploads/2022/05/Shaved-Head-with-a-Beard-for-bald-man.jpg'
    },
      {
      svcId: 9, 
      svcName: 'Beard trim',
      svcDescription: 'Trim your beard',
      svcETA: '15 minutes',
      svcPrice: 80.00,
      imgURL:'https://www.menshairstyletrends.com/wp-content/uploads/2017/02/shawn_barbz-bald-fade-combover-hairstyle-beard-1024x1024.jpg'
    }
            ];

      getAllServices() {
        return this.servicesRepository;
      }

      getServiceById(id: number) {
        return this.servicesRepository.find(x => x.svcId === id);
      }
}
