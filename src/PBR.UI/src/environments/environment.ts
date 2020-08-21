// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  SSOEnabled:  true,
  SSORequestTokenAPI: "https://ims.dev.na.baps.org/ssoapi-v2/api/auth/secured/requesttoken",
  SSOClientId:  "8F15A3B5-5631-4EEC-BD4F-1367D1F575CC",
  SSOClientSecret:  "F942F95D-E792-423E-BB6F-53656605CAED",
  SSOUrl: "https://ims.dev.na.baps.org/sso-v2",
  SSORedirectApplicationUrl: "localhost:4200/"
};
