using Newtonsoft.Json;
using Pay.Alipay.Models;
using Pay.Alipay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.Alipay.Request
{
    /// <summary>
    /// ͳһ�յ�����֧���ӿ�
    /// </summary>
    public class AlipayTradePayRequest : AlipayRequest<AlipayTradePayResponse>
    {
        #region ����
        /// <summary>
        /// �̻�������,64���ַ����ڡ��ɰ�����ĸ�����֡��»��ߣ��豣֤���̻��˲��ظ� 
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// ֧������ 
        /// ����֧����ȡֵ��bar_code
        /// ����֧����ȡֵ��wave_code
        /// </summary>
        [JsonProperty("scene")]
        public string Scene { get; set; }

        /// <summary>
        /// ֧����Ȩ�룬25~30��ͷ�ĳ���Ϊ16~24λ�����֣�ʵ���ַ��������Կ����߻�ȡ�ĸ����볤��Ϊ׼
        /// </summary>
        [JsonProperty("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// ���۲�Ʒ��
        /// </summary>
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// ��ҵ�֧�����û�id�����Ϊ�գ���Ӵ�������ֵ��Ϣ�л�ȡ���ID
        /// </summary>
        [JsonProperty("buyer_id")]
        public string BuyerId { get; set; }

        /// <summary>
        /// �����ֵΪ�գ���Ĭ��Ϊ�̻�ǩԼ�˺Ŷ�Ӧ��֧�����û�ID
        /// </summary>
        [JsonProperty("seller_id")]
        public string SellerId { get; set; }

        /// <summary>
        /// �����ܽ���λΪԪ����ȷ��С�������λ��ȡֵ��Χ[0.01,100000000] 
        /// </summary>
        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// ��۱���, total_amount ��Ӧ�ı��ֵ�λ��֧��Ӣ����GBP���۱ң�HKD����Ԫ��USD���¼���Ԫ��SGD����Ԫ��JPY�����ô�Ԫ��CAD����Ԫ��AUD��ŷԪ��EUR��������Ԫ��NZD����Ԫ��KRW
        /// </summary>
        [JsonProperty("trans_currency")]
        public string TransCurrency { get; set; }

        /// <summary>
        /// �̻�ָ���Ľ�����֣�֧��Ӣ����GBP���۱ң�HKD����Ԫ��USD���¼���Ԫ��SGD����Ԫ��JPY�����ô�Ԫ��CAD����Ԫ��AUD��ŷԪ��EUR��������Ԫ��NZD����Ԫ��KRW��̩����THB
        /// </summary>
        [JsonProperty("settle_currency")]
        public string SettleCurrency { get; set; }

        /// <summary>
        /// �����Żݼ���Ľ���λΪԪ����ȷ��С�������λ��ȡֵ��Χ[0.01,100000000]�� 
        /// �����ֵδ���룬�������ˡ������ܽ��͡����ɴ��۽������ֵĬ��Ϊ�������ܽ�-�����ɴ��۽�
        /// </summary>
        [JsonProperty("discountable_amount")]
        public decimal DiscountableAmount { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// ������������Ʒ�б���Ϣ��json��ʽ������˵�������Ʒ��ϸ˵��
        /// </summary>
        [JsonProperty("goods_detail")]
        public List<GoodsDetail> GoodsDetail { get; set; }

        /// <summary>
        /// �̻�����Ա���
        /// </summary>
        [JsonProperty("operator_id")]
        public string OperatorId { get; set; }

        /// <summary>
        /// �̻��ŵ���
        /// </summary>
        [JsonProperty("store_id")]
        public string StoreId { get; set; }

        /// <summary>
        /// �̻������ն˱��
        /// </summary>
        [JsonProperty("terminal_id")]
        public string TerminalId { get; set; }

        /// <summary>
        /// ҵ����չ����	
        /// </summary>
        [JsonProperty("extend_params")]
        public List<ExtendParams> ExtendParams { get; set; }

        /// <summary>
        /// �ñʶ��������������ʱ�䣬���ڽ��رս��ס�ȡֵ��Χ��1m��15d��m-���ӣ�h-Сʱ��d-�죬1c-���죨1c-���������£����۽��׺�ʱ����������0��رգ��� �ò�����ֵ������С���㣬 �� 1.5h����ת��Ϊ 90m
        /// </summary>
        [JsonProperty("timeout_express")]
        public string TimeoutExpress { get; set; }

        /// <summary>
        /// Ԥ��Ȩȷ��ģʽ����Ȩת���������д��룬������Ԥ��Ȩת����ҵ��ʹ�ã�Ŀǰֻ֧��PRE_AUTH(Ԥ��Ȩ��Ʒ��) 
        /// COMPLETE��ת����֧����ɽ���Ԥ��Ȩ���ⶳʣ����; NOT_COMPLETE��ת����֧����ɲ�����Ԥ��Ȩ�����ⶳʣ����
        /// </summary>
        [JsonProperty("auth_confirm_mode")]
        public string AuthConfirmMode { get; set; }

        /// <summary>
        /// �̻������ն��豸�����Ϣ������ֵҪ��֧����Լ��
        /// </summary>
        [JsonProperty("terminal_params")]
        public string TerminalParams { get; set; } 
        #endregion

        public override string GetApiName()
        {
            return "alipay.trade.pay";
        }

       
    }
}
