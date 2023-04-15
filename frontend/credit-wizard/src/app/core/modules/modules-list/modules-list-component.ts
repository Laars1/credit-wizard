import { Component, OnInit } from '@angular/core';
import { IModulDto } from 'src/app/shared/dtos/modulsDto';
import { ModuleService} from 'src/app/shared/services/api/module.service';

@Component({
  selector: 'app-modules-list',
  templateUrl: './modules-list-component.html',
  styleUrls: ['./modules-list-component.css']
})
export class ModulesListComponent implements OnInit {
  modules: IModulDto[] = []
  displayedColumns: string[] = ['id', 'name', 'abbreviation', 'description', 'etcsPoints'];

  constructor(private moduleService: ModuleService) { }

  ngOnInit(): void {
    this.moduleService.get().subscribe((s: IModulDto[]) => {
      this.modules = s;
    })
   }
}
