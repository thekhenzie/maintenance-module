import { Injectable } from '@angular/core';
import ImageCompressor from 'image-compressor.js';
import { CommonService } from './common.service';
import { UtilityService } from './utility.service';

@Injectable()
export class ImageService {
    defaultSettings: ImageCompressor.Options;

    constructor(private commonService: CommonService, private utilityService: UtilityService) {
        this.defaultSettings = {
            quality: .9,
            convertSize: 0,
            height: utilityService.appSettings.imageSizes.main.height,
            width: utilityService.appSettings.imageSizes.main.width
        };
    }

    getOptimizedByteStringImage(file: File, setting: ImageCompressor.Options = null): Promise<FileReader> {
        let defaults = Object.assign({}, this.defaultSettings);
        if(setting) Object.assign(defaults, setting);

        return new ImageCompressor().compress(file, defaults)
        .then(data => {
            let file: string = "";

            let reader: FileReader = new FileReader();
            reader.readAsDataURL(data);
            
            // return reader
            return reader;
        })
        .catch(this.commonService.handleError);
    }

    validateImageSize(file): boolean {
        if(!!!file) return true;

        return (file.size <= (30 * 1000000));
    }

    validateFileType(file): boolean{
        return (file.type.search("image") == -1);
    }
}
