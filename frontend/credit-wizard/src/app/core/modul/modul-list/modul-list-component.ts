import { Component, OnInit } from '@angular/core';
import { IModulDto } from 'src/app/shared/dtos/modulDto';
import { ModulService} from 'src/app/shared/services/api/modul.service';

/**
 * This component displays a list of modules (IModulDto) retrieved from the server
 * using the ModulService. The modules are displayed in a table with columns for id, name, abbreviation, description, and etcsPoints.
 * The component subscribes to the observable returned by the service's get() method to retrieve the modules.
*/
@Component({
  selector: 'app-modules-list',
  templateUrl: './modul-list-component.html',
  styleUrls: ['./modul-list-component.css']
})
export class ModulListComponent implements OnInit {
  moduls: IModulDto[] = []
  displayedColumns: string[] = ['id', 'name', 'abbreviation', 'description', 'etcsPoints'];

  constructor(private modulService: ModulService) { }

  /**
   * Fetch moduls to display them
   */
  ngOnInit(): void {
    this.modulService.get().subscribe((s: any) => {
      this.moduls = s;
    })
   }
}
