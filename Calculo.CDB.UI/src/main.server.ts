import { bootstrapApplication } from '@angular/platform-browser';
import { FormCdbComponent } from './app/form-cdb/form-cdb.component';
import { config } from './app/app.config.server';

const bootstrap = () => bootstrapApplication(FormCdbComponent, config);

export default bootstrap;
