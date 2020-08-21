export class AppSettings {
    SSOEnabled: boolean = true;
    SSORequestTokenAPI: string = "https://ims.dev.na.baps.org/ssoapi-v2/api/auth/secured/requesttoken";
    SSOClientId: string = "4DABFF26-F7D2-4BB2-BF0B-C168E035A9EC";
    SSOClientSecret: string = "5B9BFFAF-94F7-4D51-9BDB-C950A035589B";
    SSOUrl: string = "https://ims.dev.na.baps.org/sso-v2";
    SSORedirectApplicationUrl: string = "localhost:4200/";
}