import { commonEnvironment } from "./environment.common";

export const _settings = {
  production: true,
  // ApiUrl: `/api`
}
export const environment = Object.assign({}, commonEnvironment, _settings);