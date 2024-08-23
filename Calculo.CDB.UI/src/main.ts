import { bootstrapApplication } from '@angular/platform-browser';
import { FormCdbComponent } from './app/form-cdb/form-cdb.component';
import { provideHttpClient, withFetch } from '@angular/common/http';

bootstrapApplication(FormCdbComponent, {
  providers: [provideHttpClient(withFetch())]
})
.catch(err => console.error(err));
