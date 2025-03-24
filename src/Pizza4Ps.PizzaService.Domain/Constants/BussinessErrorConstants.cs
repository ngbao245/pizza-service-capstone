namespace Pizza4Ps.PizzaService.Domain.Constants
{
    public static class BussinessErrorConstants
    {
        public class AdditionalFeeErrorConstant
        {
            public const string VALUE_INVALID = "Giá tiền không được âm";
            public const string ADDITIONAL_FEE_NOT_FOUND = "Phụ phí không tìm thấy";
        }

        public class WorkingSlotRegisterErrorConstant
        {
            public const string INVALID_WORKING_SLOT_REGISTER_STATUS = "Trạng thái đăng ký lịch làm việc không tìm thấy";
            public const string WORKING_SLOT_REGISTER_NOT_FOUND = "Không tìm thấy đơn đăng ký lịch làm việc";
            public const string WORKING_SLOT_REGISTER_ALREADY_APPROVED = "Đơn đăng ký lịch làm việc đã được duyệt";
            public const string WORKING_SLOT_REGISTER_ALREADY_REJECTED = "Đơn đăng ký lịch làm việc đã bị từ chối";
        }

        public class ConfigErrorConstant
        {
            public const string CONFIG_NOT_FOUND = "Không tìm thấy config";
            public const string CONFIG_INVALID = "Config không hợp lệ";
        }

        public class RoleErrorConstant
        {
            public const string ROLE_NOT_FOUND = "Không tìm thấy vị trí";
        }

        public class WorkingSlotErrorConstant
        {
            public const string WORKING_SLOT_NOT_FOUND = "Không tìm thấy slot làm việc";
            public const string ALREADY_REGISTERED = "Nhân viên đã đăng ký ca làm việc này";
        }

        public class ShiftErrorConstant
        {
            public const string SHIFT_NOT_FOUND = "Ca làm không tìm thấy";
        }

        public class CurrentOrderIdExisted
        {
            public const string CURRENT_ORDER_ID_EXISTED = "Bàn đã tồn tại mã đơn hàng";
        }

        public class ProductOptionErrorConstant
        {
            public const string PRODUCTOPTION_NOT_FOUND = "Product option không tìm thấy";
        }

        public class DayErrorConstant
        {
            public const string DAY_NOT_FOUND = "Không tìm thấy ngày trong tuần";
        }

        public class StaffScheduleErrorConstant
        {
            public const string STAFFSCHEDULE_NOT_FOUND = "Lịch làm việc nhân viên không tìm thấy";
        }

        public class IngredientErrorConstant
        {
            public const string INGREDIENT_NOT_FOUND = "Nguyên liệu không tìm thấy";
        }

        public class StaffZoneScheduleErrorConstant
        {
            public const string STAFFZONESCHEDULE_NOT_FOUND = "Lịch làm việc nhân viên theo khu vực không tìm thấy";
        }

        public class WorkingTimeErrorConstant
        {
            public const string WORKINGTIME_NOT_FOUND = "Working time không tìm thấy";
        }

        public class TableBookingErrorConstant
        {
            public const string TABLEBOOKING_NOT_FOUND = "Table booking không tìm thấy";
        }

        public class SizeErrorConstant
        {
            public const string SIZE_NOT_FOUND = "Kích thước bánh pizza không tìm thấy";
        }

        public class BookingErrorConstant
        {
            public const string BOOKING_NOT_FOUND = "Bàn đặt không tìm thấy";
            public const string BOOKING_SLOT_FULL = "Hiện tại đã không còn bàn trống";
            public const string INVALID_BOOKING_STATUS = "Trạng thái giữ chỗ không hợp lệ";
            public const string INVALID_BOOKING_CAPACITY = "Số lượng người không phù hợp với khả năng bàn giữ chỗ";
            public const string NOT_ASSIGNED_TABLE = "Chưa được xếp bàn ngồi";

        }

        public class BookingSlotErrorConstant
        {
            public const string BOOKING_SLOT_NOT_FOUND = "Không thể đặt bàn vào thời gian này";
        }
        public class OrderVoucherErrorConstant
        {
            public const string ORDERVOUCHER_NOT_FOUND = "Order voucher không tìm thấy";
        }

        public class CategoryErrorConstant
        {
            public const string CATEGORY_NOT_FOUND = "Danh mục không tìm thấy";
        }

        public class ProductErrorConstant
        {
            public const string PRODUCT_NOT_FOUND = "Món ăn không tìm thấy";
        }

        public class ProductSizeErrorConstant
        {
            public const string PRODUCTSIZE_NOT_FOUND = "Kích cỡ Món ăn không tìm thấy";
            public const string PRODUCTSIZE_EXISTED = "Kích cỡ Món ăn đã tồn tại";

        }

        public class RecipeErrorConstant
        {
            public const string RECIPE_NOT_FOUND = "Công thức không tìm thấy";
        }

        public class OrderItemErrorConstant
        {
            public const string INVALID_ORDER_ITEM_STATUS = "Trạng thái món ăn không phù hợp";
            public const string ORDER_ITEM_CANNOT_DONE = "Order item không tìm thấy";
            public const string ORDER_ITEM_CANNOT_SERVED = "Món ăn không thể được phục vụ";
            public const string ORDER_ITEM_NOT_FOUND = "Món ăn không thể hoàn thành";

        }

        public class OrderItemDetailErrorConstant
        {
            public const string ORDER_ITEM_DETAIL_NOT_FOUND = "Order Item Detail không tìm thấy";
        }

        public class OptionItemErrorConstant
        {
            public const string OPTION_ITEM_NOT_FOUND = "lựa chọn không tìm thấy";
        }

        public class PaymentErrorConstant
        {
            public const string PAYMENT_NOT_FOUND = "Payment không tìm thấy";
        }

        public class CustomerErrorConstant
        {
            public const string CUSTOMER_NOT_FOUND = "Khách hàng không tìm thấy";
        }

        public class FeedbackErrorConstant
        {
            public const string FEEDBACK_NOT_FOUND = "Feedback không tìm thấy";
        }

        public class OrderErrorConstant
        {
            public const string ORDER_NOT_FOUND = "Đơn hàng không tìm thấy";
            public const string ORDER_CANNOT_CHECK_OUT = "Đơn hàng đã được xuất hoá đơn hoặc thanh toán";
            public const string ORDER_CANNOT_CANCEL_CHECK_OUT = "Đơn hàng chưa được xuất hoá đơn hoặc thanh toán";
            public const string ORDER_CANNOT_PAY = "Đơn hàng chưa được check out hoặc đã được thanh toán";
            public const string ORDER_STATUS_INVALID_TO_ORDER = "Đơn hàng đã được xuất hoá đơn hoặc được thanh toán";
        }

        public class StaffErrorConstant
        {
            public const string STAFF_NOT_FOUND = "Nhân viên không tìm thấy";
            public const string INVALID_STAFF_STATUS = "Trạng thái nhân viên không phù hợp";
            public const string INVALID_STAFF_TYPE = "Loại nhân viên không phù hợp";
        }

        public class OptionErrorConstant
        {
            public const string OPTION_NOT_FOUND = "Option không tìm thấy";
        }

        public class StaffZoneErrorConstant
        {
            public const string STAFFZONE_NOT_FOUND = "Khu vực nhân viên không tìm thấy";
        }

        public class TableErrorConstant
        {
            public const string TABLE_NOT_FOUND = "Bàn không tìm thấy";
            public const string TABLE_NOT_HAVE_ORDER = "Bàn không có đơn hàng nào";
            public const string TABLE_ORDER_NOT_HAVE_ORDER_ITEM = "Đơn hàng không có món ăn nào";
            public const string INVALID_TABLE_STATUS = "Trạng thái bàn không hợp lệ";
            public const string TABLE_ORDER_NOT_HAVE_TOTAL_PRICE = "Đơn hàng chưa được tính tổng tiền";
            public const string CAPACITY_INVALID = "Tổng chổ ngồi phải lớn hơn 0";
        }

        public class VoucherErrorConstant
        {
            public const string VOUCHER_NOT_FOUND = "Voucher không tìm thấy";
        }

        public class VoucherTypeErrorConstant
        {
            public const string TOTAL_QUANTITY_INVALID = "Tổng số lượng phải lớn hơn 0";
            public const string VOUCHER_TYPE_NOT_FOUND = "Kiểu khuyến mãi không tìm thấy";
        }

        public class ZoneErrorConstant
        {
            public const string ZONE_NOT_FOUND = "Khu vực không tìm thấy";
        }
    }
}
