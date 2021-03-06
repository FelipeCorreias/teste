import { Component, OnInit } from '@angular/core';
import { Patch } from '../../models/patch.model';
import { PatchesService } from '../../services/patches.service';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-patches-list',
  templateUrl: './patches-list.component.html',
  styleUrls: ['./patches-list.component.css']
})
export class PatchesListComponent implements OnInit {
  public patches: Patch[];
  public _patchesService: PatchesService;
  public _route: ActivatedRoute;

  constructor(private patchesService: PatchesService, private route: ActivatedRoute) {
    this._patchesService = patchesService;
    this._route = route;
  }

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.patches = null;
      console.log(params['model']);
      if (params['model'] != null) {
        this.getPatchesByModel(params['model'])
      } else {
        this.getPatches();
      }
    });
  }

  getPatchesByModel(model: string) {
    this._patchesService.getPatchesListByModel(model).subscribe(data => { this.patches = data; })
      , err => {
        console.log(err);
      };
  }

  getPatches() {
    this._patchesService.getPatchesList().subscribe(data => { this.patches = data; })
      , err => {
        console.log(err);
      };
  }

  getPatchFile(id: number) {
    return this._patchesService.getPatchFile(id);
  }


}
