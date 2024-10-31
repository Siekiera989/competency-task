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
  columns = signal<TableColumn[]>([
    { header: "ID", field: "id" },
    { header: "Name", field: "name" },
    { header: "Age", field: "age" },
  ]);

  data = signal<Array<Record<string, any>>>([
    { id: 1, name: "John Doe", age: 30 },
    { id: 2, name: "Jane Smith", age: 25 },
    { id: 3, name: "Alice Johnson", age: 40 },
  ]);
}
```

`sample.component.html`

```html
<h2>User Table</h2>
<app-reusable-table [dataInput]="data()" [columnsInput]="columns()"></app-reusable-table>
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

### Signals explanation

Using signals in Angular introduces a more powerful and efficient way of handling reactivity, especially for component-based frameworks. Here’s a breakdown of why signals are beneficial:

1. Fine-Grained Reactivity
   Targeted Updates: Signals allow for fine-grained reactivity, meaning only specific parts of the component that depend on a signal re-render when the signal’s value changes. This is different from traditional change detection, where even minor updates can trigger changes in the entire component tree.
   Improved Performance: By reducing unnecessary re-renders, signals help increase performance, especially in applications with complex data flows and large component trees.
2. Simplified State Management
   Standalone State Handling: Signals provide a straightforward, standalone way to manage component state. They eliminate the need for external libraries or complex setups, making state management more intuitive and localized to the component.
   Reactive Data Flow: Signals help create a clear, reactive data flow. By using signals, you can ensure that updates propagate automatically and consistently, reducing the need for manual state handling or explicit reactivity triggers.
3. Predictable and Readable Code
   Explicit Data Updates: With signals, data updates are explicit. You control when and how data changes by using functions like .set(), .update(), or .mutate(). This makes code easier to understand, as the logic for data changes is straightforward and centralized.
   Easy Debugging: Signals simplify debugging because state changes are easier to trace, leading to more predictable application behavior.
4. Decoupling from Angular’s Zone.js and Change Detection
   No Zones Needed: Signals work outside of Angular’s traditional Zone.js, which reduces the reliance on Angular's global change detection and makes code more efficient by avoiding unnecessary checks.
   Angular 17 Compatibility: Angular has introduced signals with the goal of evolving the framework’s change detection strategy, making it easier to build apps without zones in the future. This positions Angular well for applications that need better performance and finer control over reactivity.
5. Built for Modern Angular Patterns
   Integration with Directives and Reactive Utilities: Signals integrate smoothly with Angular’s reactive primitives, like computed and effect, as well as with new reactive templates and directives.
   Reactive APIs for Component Inputs: Signals allow developers to pass reactive data between components, making it easier to build reusable components that react automatically to changes in inputs.
6. Enhanced Developer Experience
   Improved Maintainability: The clean, focused reactivity of signals leads to simpler, more maintainable code by reducing the complexity associated with state management and event handling.
   Future-Proofing: Since Angular is moving toward a more reactive approach, using signals aligns with Angular’s future direction, providing a sustainable and scalable pattern for app development.
   In summary, signals bring targeted reactivity, improved performance, simplified state management, and alignment with Angular’s future vision, making them an excellent choice for building scalable, responsive Angular applications.

### Summary

Using standalone components in Angular provides a highly modular approach suitable for small to medium-sized projects and reusable UI elements. Using a shared NgModule or CSS variables for larger applications or when shared theming is required.
