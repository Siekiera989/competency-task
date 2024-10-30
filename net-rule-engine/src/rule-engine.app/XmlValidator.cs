using System.Xml.Linq;
using System.Xml.XPath;

namespace rule_engine.app;

public class XmlValidator(XDocument document, List<TemplateRule> rules)
{
    private readonly XDocument _document = document;
    private readonly List<TemplateRule> _rules = rules;
    
    public List<string> ValidateDocument()
    {
        var violations = new List<string>();
        foreach (var rule in _rules)
        {
            var nodes = _document.XPathSelectElements($"//contentItemRef[@category='{rule.Category}']");
            foreach (var node in nodes)
            {
                // Check for forbidden sibling rule
                if (!string.IsNullOrEmpty(rule.ForbiddenSiblingCategory))
                {
                    var sibling = node.ElementsAfterSelf().FirstOrDefault(e => e.Attribute("category")?.Value == rule.ForbiddenSiblingCategory);
                    if (sibling != null)
                    {
                        violations.Add($"Node '{node}' cannot have a sibling '{sibling}'");
                    }
                }
            }
        }
        return violations;
    }
    
    public List<string> GetAllowedTemplates(string xpath)
    {
        var node = _document.XPathSelectElement(xpath);
        if (node == null) return [];

        var allowedTemplates = _rules
            .Where(r => r.Category == node.Attribute("category")?.Value)
            .Select(r => r.RequiredCousinCategory)
            .Where(c => c != null)
            .ToList();

        return allowedTemplates;
    }
    
    public bool CanMoveNode(string nodeXpath, string newParentXpath)
    {
        var node = _document.XPathSelectElement(nodeXpath);
        var newParent = _document.XPathSelectElement(newParentXpath);

        if (node == null || newParent == null)
            return false;

        // Validate movement based on specific rules (example logic here)
        return newParent.Elements().All(e => e.Attribute("category")?.Value != node.Attribute("category")?.Value);
    }
}