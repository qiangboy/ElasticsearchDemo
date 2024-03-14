using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Nest;

namespace ElasticsearchDemo;

public partial class TbHotel
{
    /// <summary>
    /// 酒店id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 酒店名称
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 酒店地址
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// 酒店价格
    /// </summary>
    public int Price { get; set; }

    /// <summary>
    /// 酒店评分
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// 酒店品牌
    /// </summary>
    public string Brand { get; set; } = null!;

    /// <summary>
    /// 所在城市
    /// </summary>
    public string City { get; set; } = null!;

    /// <summary>
    /// 酒店星级，1星到5星，1钻到5钻
    /// </summary>
    public string? StarName { get; set; }

    /// <summary>
    /// 商圈
    /// </summary>
    public string? Business { get; set; }

    /// <summary>
    /// 纬度
    /// </summary>
    public string Latitude { get; set; } = null!;

    /// <summary>
    /// 经度
    /// </summary>
    public string Longitude { get; set; } = null!;

    /// <summary>
    /// 酒店图片
    /// </summary>
    public string? Pic { get; set; }

    [NotMapped]
    public GeoLocation Location => new(double.Parse(Latitude), double.Parse(Longitude));
}
