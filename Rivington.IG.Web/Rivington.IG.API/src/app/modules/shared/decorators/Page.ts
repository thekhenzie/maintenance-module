// const Reflect = global['Reflect'];
// export function Page(_props) {
//   _props = Object.assign({}, defaultProps, _props);

//   return function (cls) {
//     Reflect.defineMetadata('annotations', [_props], cls);
//   }
// }

// export function CustomComponentDecorator(_props) {
//   _props = Object.assign({}, defaultProps, _props);
//   Object.setPrototypeOf(_props, DecoratorFactory);

//   return function (cls) {
//     Reflect.defineMetadata('annotations', [_props], cls);
//   }
// }

// export function CustomComponentDecorator(_props) {
//   let props = Object.create(DecoratorFactory);
//   props = Object.assign(props, defaultComponentProps, _props);

//   return function (cls) {
//     Reflect.defineMetadata('annotations', [props], cls);
//   }
// }