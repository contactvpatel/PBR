export class AppSettings {
  ssoEnabled = true;
  ssoRequestTokenAPI =
    'https://ims.dev.na.baps.org/ssoapi-v2/api/auth/secured/requesttoken';
  ssoClientId = '4DABFF26-F7D2-4BB2-BF0B-C168E035A9EC';
  ssoClientSecret = '5B9BFFAF-94F7-4D51-9BDB-C950A035589B';
  ssoUrl = 'https://ims.dev.na.baps.org/sso-v2';
  ssoRedirectApplicationUrl = 'localhost:4200/';
}

export type SortColumn = keyof Account | '';
export type SortDirection = 'asc' | 'desc' | '';
