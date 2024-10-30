## Use the Table Component in Another Component

Generate a sample component:

`ng generate component sample --standalone`

In SampleComponent, define table data and columns, and import the table component directly:

`sample.component.ts:`

```typescript
import { Component } from "@angular/core";
import { ReusableTableComponent } from "../shared-styles/reusable-table/reusable-table.component";

@Component({
  selector: "app-sample",
  standalone: true,
  imports: [ReusableTableComponent],
  templateUrl: "./sample.component.html",
  styleUrls: ["./sample.component.scss"],
})
export class SampleComponent {
  tableData = [
    { name: "John Doe", age: 30, email: "john@example.com" },
    { name: "Jane Smith", age: 25, email: "jane@example.com" },
    { name: "Alice Johnson", age: 28, email: "alice@example.com" },
  ];

  columns = [
    { header: "Name", field: "name" },
    { header: "Age", field: "age" },
    { header: "Email", field: "email" },
  ];
}
```

Use the SampleComponent in AppComponent.

`app.component.ts:`

```typescript
import { Component } from "@angular/core";
import { SampleComponent } from "./sample/sample.component";

@Component({
  selector: "app-root",
  standalone: true,
  imports: [SampleComponent],
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
})
export class AppComponent {}
```

Add <app-sample> to app.component.html:

```html
<app-sample></app-sample>
```

# Pros and Cons of Standalone Components

### Pros

**Modularity:** Each component can define its own dependencies, which enhances modularity and reduces dependency coupling.

**Reduced Complexity:** Standalone components can reduce the need for NgModules in small to medium projects, simplifying the architecture.

**Reusable and Isolated:** Components can be easily reused across different parts of the application or even across applications without additional setup.

### Cons

**Redundant Imports:** For larger applications, importing dependencies directly in each component can lead to redundant code.

**Limited Compatibility:** Not all libraries or Angular features are fully compatible with standalone components, though support is improving.

**Style Scoping:** Component styles are isolated, so global theming can be less straightforward without CSS variables or theme managers.

### Alternative Approaches

1. _Shared NgModule with Predefined Styles:_

Instead of relying on standalone components, create a SharedModule to hold reusable components and styles.

**Pros:** Easier to manage styles and themes globally in larger applications.

**Cons:** Less flexible, as all components must use styles defined in the SharedModule, and updates might affect all components using the module.

2. _CSS Variables for Theming:_

Use CSS variables to define a global theme. Each component then uses these variables for styling, allowing for easy, centralized theming.

**Pros:** Enables global theming without tightly coupling components.

**Cons:** Requires CSS variable support and configuration in each consuming project.

3. _Scoped Feature Modules:_

Use feature modules to organize groups of related components, allowing for feature-specific styling and configuration.

**Pros:** Good for large applications with distinct feature sets and reduces inter-module dependency.

**Cons:** More complex to manage, and styles may need to be repeated if features share UI elements.

### Summary

Using standalone components in Angular provides a highly modular approach suitable for small to medium-sized projects and reusable UI elements. Using a shared NgModule or CSS variables for larger applications or when shared theming is required.
