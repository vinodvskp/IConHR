using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IDocumentService
    {
        int SaveDocument(DocumentModel model);
        IEnumerable<DocumentModel> GetDocuments();
        IEnumerable<DocumentModel> GetDocuments(int employeeId, int companyId,string fromScreen);
        int UpdateDocument(DocumentModel model);
        int DeleteDocument(int id);
        IEnumerable<ChoiceOptionModel> GetDocumentCategoryTypes();
    }
}
