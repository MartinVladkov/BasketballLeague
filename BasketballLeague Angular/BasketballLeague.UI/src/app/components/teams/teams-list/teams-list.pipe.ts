import { Pipe, PipeTransform } from '@angular/core';
import { Team } from 'src/app/models/team';


@Pipe({ name: 'team' })
export class TeamPipe implements PipeTransform {
  transform(values: Team[], filter: string): Team[] {
    if (!filter || filter.length === 0) {
      return values;
    }

    if (values.length === 0) {
      return values;
    }

    filter = filter.toLocaleLowerCase();

    return values.filter((value: Team) => {
      return JSON.stringify(value).toLowerCase().includes(filter);
    });
    
  }
}