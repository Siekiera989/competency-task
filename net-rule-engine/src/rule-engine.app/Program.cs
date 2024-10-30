using System.Xml.Linq;

namespace rule_engine.app;

internal class Program
{
    public static void Main(string[] args)
    {
        // Sample XML document
        var document = XDocument.Load("sample.xml");

        // Define some sample rules
        List<TemplateRule> rules =
        [
            new TemplateRule(category: "Lesson", forbiddenSiblingCategory: "Article")
            {
                Subcategory = null,
                RequiredCousinCategory = null
            },

            new TemplateRule
            {
                Category = "ActivitySet",
                Subcategory = null,
                ForbiddenSiblingCategory = null,
                RequiredCousinCategory = "Activity"
            }
        ];

        var validator = new XmlValidator(document, rules);

        // Validate the document against rules
        var violations = validator.ValidateDocument();
        foreach (var violation in violations)
        {
            Console.WriteLine($"Violation: {violation}");
        }

        // Get allowed templates for a specific node
        var allowedTemplates = validator.GetAllowedTemplates("//organization/contentItemRef[@idref='0a1733ffac774ce6b286a6072f8b900d']");
        Console.WriteLine("Allowed Templates:");
        foreach (var template in allowedTemplates)
        {
            Console.WriteLine(template);
        }

        // Check if a node can be moved
        bool canMove = validator.CanMoveNode("//contentItemRef[@idref='97b4b2e762344e22a6e9e395190bd262']", "//organization/contentItemRef[@idref='227ce7e771cc4d2e924f3e63c229c5d7']");
        Console.WriteLine($"Can move node: {canMove}");
        
        Console.ReadLine();
    }
}