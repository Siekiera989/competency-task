# Architecture Overview
### Requirements Recap:

XML documents need to be validated based on specific structural rules. Rules are provided in a separate XML document. The solution needs to:
- List allowed templates for a node.
- Validate the document structure.
- Allow checking if a node can be moved.
- Identify nodes violating placement rules.


### Architectural Approach:

#### Option 1: Rule-based Validation Using XPath and LINQ to XML
**Description:** 

Use XPath to locate nodes within the XML document and LINQ to XML for efficient in-memory processing.

*Pros:*
- Allows precise, efficient XML traversal.
- LINQ to XML integrates smoothly with XPath queries.
- Lightweight and performant for documents that fit into memory.

*Cons:*
- Limited flexibility if rule complexity increases.
- May need complex XPath expressions to handle deeper hierarchical validation.

#### Option 2: XML DOM Manipulation with Custom Rules Engine
**Description:**

Build a small rules engine that relies on XML DOM traversal and custom rule definitions to validate the document structure.

*Pros:*
- Allows for complex rule definitions and easier extension if more rule types are needed.
- Clear and explicit rule processing flow.

*Cons:*
- Higher memory and processing requirements.
- Requires more extensive coding to handle various rule relationships.

 

Chosen Approach: **Option 1**

Using XPath and LINQ to XML offers a lightweight, maintainable solution suitable for the given requirements. This approach allows validation and query operations with less complexity.

# API Description
The API provided by XmlValidator allows for:

*Validation:* `ValidateDocument()` returns a list of validation errors.

*Allowed Templates:* `GetAllowedTemplates(xpath)` returns a list of allowed template categories for a specified node.

*Node movability:* `CanMoveNode(nodeXpath, newParentXpath)` checks if a node can be moved to a specified location.

This solution can handle a range of validation rules, is easily extendable, and provides efficient XML document manipulation and validation.