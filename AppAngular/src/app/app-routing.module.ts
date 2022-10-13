import { CampanhasViewComponent } from './views/campanhas-view/campanhas-view.component';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VacinasComponent } from './views/vacinas/vacinas.component';

const routes: Routes = [
  {
    path: '',
    component: VacinasComponent,

  },
  {
    path: 'vacinas',
    component: VacinasComponent,

  },
  {
    path: 'campanhas',
    component: CampanhasViewComponent,

  }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
