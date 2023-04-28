import { Component, OnInit } from '@angular/core';
import { IModulDto } from 'src/app/shared/dtos/modulDto';
import { ModulService} from 'src/app/shared/services/api/module.service';

@Component({
  selector: 'app-modules-list',
  templateUrl: './modul-list-component.html',
  styleUrls: ['./modul-list-component.css']
})
export class ModulListComponent implements OnInit {
  moduls: IModulDto[] = []
  displayedColumns: string[] = ['id', 'name', 'abbreviation', 'description', 'etcsPoints'];

  constructor(private modulService: ModulService) { }

  ngOnInit(): void {
    this.modulService.get().subscribe((s: any) => {
      this.moduls = s;
    })
   }
}
