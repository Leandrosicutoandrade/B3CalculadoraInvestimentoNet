import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormCdbComponent } from './form-cdb.component';

describe('FormCdbComponent', () => {
  let component: FormCdbComponent;
  let fixture: ComponentFixture<FormCdbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormCdbComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormCdbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
