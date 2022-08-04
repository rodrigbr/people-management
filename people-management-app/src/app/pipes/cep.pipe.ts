import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'cEP'
})
export class CEPPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
