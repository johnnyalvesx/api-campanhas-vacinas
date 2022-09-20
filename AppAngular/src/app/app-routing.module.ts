import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VacinasComponent } from './components/vacinas/vacinas.component';

const routes: Routes = [{
  path: 'vacinas', component: VacinasComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
