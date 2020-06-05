/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/5/8 13:21:01
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.LoongLog.FX45
{

    internal static class StringExtensions
    {
        public static bool IsNotNullOrEmptyOrSpace(this string self) {
            return !string.IsNullOrEmpty(self) && !string.IsNullOrWhiteSpace(self);
        }
    }
}
