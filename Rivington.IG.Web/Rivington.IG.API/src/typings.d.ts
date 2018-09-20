/* SystemJS module definition */
declare var module: NodeModule;
interface NodeModule {
  id: string;
}

// https://stackoverflow.com/a/47631560/1035039
import * as $ from 'jquery';
// https://medium.com/all-is-web/angular-5-using-jquery-plugins-5edf4e642969
interface JQuery {
  // <your-plugin-name>(options?: any): any;
}