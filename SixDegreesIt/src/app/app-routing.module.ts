import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EliminarComponent } from './eliminar/eliminar.component';
import { FormularioComponent } from './home/formulario/formulario.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'eliminar', component:EliminarComponent},
  {path:'formulario', component:FormularioComponent},
  {path:'**', pathMatch:'full', redirectTo:'formulario'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
