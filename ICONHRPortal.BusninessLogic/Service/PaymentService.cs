using AutoMapper;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;

namespace ICONHRPortal.BusninessLogic.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository = null;
        private readonly ICountryRepository _countryRepository = null;
        private readonly ICardTypeRepository _cardTypeRepository = null;
        private readonly ICardExpireYearRepository _cardExpireYearRepository = null;
        private readonly ICardExpireMonthRepository _cardExpireMonthRepository = null;
        public PaymentService(IPaymentRepository paymentRepository, ICountryRepository countryRepository,
            ICardTypeRepository cardTypeRepository, ICardExpireYearRepository cardExpireYearRepository, ICardExpireMonthRepository cardExpireMonthRepository)
        {
            _paymentRepository = paymentRepository;
            _countryRepository = countryRepository;
            _cardTypeRepository = cardTypeRepository;
            _cardExpireYearRepository = cardExpireYearRepository;
            _cardExpireMonthRepository = cardExpireMonthRepository;
        }

        public CountryCardDetailsModel GetCountryCardDetails()
        {
            var ccDetailModel = new CountryCardDetailsModel();

            ccDetailModel.Countries = _countryRepository.GetAll().Select(x => new ChoiceOptionModel
            {
                id = x.CountryID,
                text = x.CountryName
            }).ToList();

            ccDetailModel.CardTypes = _cardTypeRepository.GetAll().Select(x => new ChoiceOptionModel
            {
                id = x.CardTypeID,
                text = x.CardType
            }).ToList();

            ccDetailModel.CardExpireYears = _cardExpireYearRepository.GetAll().Select(x => new ChoiceOptionModel
            {
                id = x.CardExpYearID,
                text = x.CardExpYear.HasValue ? x.CardExpYear.ToString() : string.Empty
            }).ToList();

            ccDetailModel.CardExpireMonths = _cardExpireMonthRepository.GetAll().Select(x => new ChoiceOptionModel
            {
                id = x.CardExpMonthID,
                text = x.CardExpMonthName

            }).ToList();

            return ccDetailModel;
        }

        public int SaveCreditCardDetailModel(CreditCardDetailModel model)
        {
            var ccDetail = Mapper.DynamicMap<tblCreditCardDetail>(model);
            _paymentRepository.Add(ccDetail);
            return _paymentRepository.SaveChanges();
        }
    }
}
