import * as _ from 'lodash';
import 'reflect-metadata';
import { createAnnotationFactory, reflectAnnotations } from 'reflect-annotations'

export function Inherit() {
    return (target: Function) => {
        let parentTarget = Object.getPrototypeOf(target.prototype).constructor;

        let metaInformations = reflectAnnotations(target);
        let parentMetaInformation = reflectAnnotations(parentTarget);

        // let metaInformations = Reflect.getOwnMetadata("annotations", target);
        // let parentMetaInformation = Reflect.getMetadata("annotations", parentTarget);

        let allMetadataKeys = Reflect.getMetadataKeys(target);
        let parentMetadataKeys = Reflect.getMetadataKeys(parentTarget);

        if (!_.isNil(metaInformations) && !_.isNil(parentMetaInformation)) {
            for (let metaInformation of metaInformations) {
                for (let parentMetadata of parentMetaInformation) {
                    if (parentMetadata.constructor === metaInformation.constructor) {
                        Object.keys(parentMetadata).forEach(key => {
                            const parentValue = parentMetadata[key];
                            const childValue = metaInformation[key];
                            if (!_.isNil(parentValue) && _.isNil(childValue)) {
                                if (_.isArray(parentValue) && _.isArray(childValue)) {
                                    metaInformation[key] = parentValue[key].concat(childValue);
                                } else if (_.isObject(parentValue) && _.isObject(childValue)) {
                                    Object.assign(metaInformation[key], parentValue);
                                } else {
                                    metaInformation[key] = parentMetadata[key];
                                }
                            }
                        });
                    }
                }
            }
        }
    };
}