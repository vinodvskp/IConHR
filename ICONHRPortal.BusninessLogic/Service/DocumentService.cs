using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository = null;
        private readonly IDocumentCategoryTypeRepository _documentCategoryTypeRepository = null;

        public DocumentService(IDocumentRepository documentRepository, IDocumentCategoryTypeRepository documentCategoryTypeRepository)
        {
            _documentRepository = documentRepository;
            _documentCategoryTypeRepository = documentCategoryTypeRepository;
        }

        public int DeleteDocument(int id)
        {
            var document = _documentRepository.Find(x => x.DocumentID == id).FirstOrDefault();
            if (document != null)
            {
                document.LastUpdatedDate = DateTime.Now;
                document.Status = false;
                _documentRepository.Update(document);
                return _documentRepository.SaveChanges();
            }

            return 0;
        }

        public IEnumerable<ChoiceOptionModel> GetDocumentCategoryTypes()
        {
            return _documentCategoryTypeRepository.GetAll().Select(x => new ChoiceOptionModel()
            {
                id = x.DocumentCategoryTypeID,
                text = x.DocumentCategoryName
            }).ToList();
        }

        public IEnumerable<DocumentModel> GetDocuments()
        {
            return Mapper.DynamicMap<List<DocumentModel>>(_documentRepository.GetAll().Where(x => x.Status != false).ToList());
        }

        /// <summary>
        /// Gets the documents.
        /// Employee screen---> filter by selected employee id and companyid and IsCompanyAccessOnly = true and EmployeeAcess= true
        /// Me screen -----> filter by logged id and companyid and IsCompanyAccessOnly = true and EmployeeAcess = true
        /// Document menu on click screen ----> filter by only companyid and IsCompanyAccessOnly = true
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="fromScreen">From screen.</param>
        /// <returns></returns>
        public IEnumerable<DocumentModel> GetDocuments(int employeeId, int companyId, string fromScreen)
        {
            if (fromScreen == "employeeScreen")
            {
                return Mapper.DynamicMap<List<DocumentModel>>(_documentRepository.GetAll()
                    .Where(x => x.Status != false && x.EmpID == employeeId && x.CompanyId == companyId).ToList());
            }
            else if (fromScreen == "companyScreen")
            {
                return Mapper.DynamicMap<List<DocumentModel>>(_documentRepository.GetAll()
                    .Where(x => x.Status != false && x.IsCompanyAccessOnly == true && x.CompanyId == companyId).ToList());
            }
            return null;
        }

        public int SaveDocument(DocumentModel model)
        {
            if (model.FromScreen == "companyScreen")
            {
                model.IsCompanyAccessOnly = true;
            }
            else
            {
                model.IsCompanyAccessOnly = false;
            }
            model.CreatedDate = DateTime.Now;
            var documentEntity = Mapper.DynamicMap<tblDocument>(model);
            _documentRepository.Add(documentEntity);
            return _documentRepository.SaveChanges();
        }

        public int UpdateDocument(DocumentModel model)
        {
            if (model.FromScreen == "companyScreen")
            {
                model.IsCompanyAccessOnly = true;
            }
            else
            {
                model.IsCompanyAccessOnly = false;
            }

            var document = _documentRepository.Find(x => x.DocumentID == model.DocumentID).FirstOrDefault();
            if (document != null)
            {
                model.LastUpdatedDate = DateTime.Now;
                Mapper.CreateMap<DocumentModel, tblDocument>()
                    .ForMember(dest => dest.DocumentID, opt => opt.Ignore()); // ignore primary key while update/delete
                tblDocument documentEnity = (tblDocument)Mapper.Map(model, document);

                return _documentRepository.SaveChanges();
            }

            return 0;
        }
    }
}
