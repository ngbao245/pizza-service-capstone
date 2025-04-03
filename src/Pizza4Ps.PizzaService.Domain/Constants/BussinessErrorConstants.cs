namespace Pizza4Ps.PizzaService.Domain.Constants
{
    public static class BussinessErrorConstants
    {
        public class AdditionalFeeErrorConstant
        {
            public const string VALUE_INVALID = "Số tiền không thể là số âm";
            public const string ADDITIONAL_FEE_NOT_FOUND = "Không tìm thấy phụ phí";
        }

        public class WorkingSlotRegisterErrorConstant
        {
            public const string INVALID_WORKING_SLOT_REGISTER_STATUS = "Trạng thái đăng ký ca làm việc không hợp lệ";
            public const string WORKING_SLOT_REGISTER_NOT_FOUND = "Không tìm thấy đơn đăng ký ca làm việc";
            public const string WORKING_SLOT_REGISTER_ALREADY_APPROVED = "Đăng ký ca làm việc đã được chấp thuận";
            public const string WORKING_SLOT_REGISTER_ALREADY_REJECTED = "Đăng ký ca làm việc đã bị từ chối";
        }

        public class SwapWorkingSlotErrorConstant
        {
            public const string SWAP_WORKING_SLOT_ALREADY_REJECTED = "Yêu cầu đổi ca làm việc đã bị từ chối";
            public const string SWAP_WORKING_SLOT_ALREADY_PENDING_APPROVE = "Yêu cầu đổi ca làm việc đang chờ quản lý duyệt";
            public const string SWAP_WORKING_SLOT_ALREADY_APPROVED = "Yêu cầu đổi ca làm việc đã được chấp thuận";
            public const string SWAP_WORKING_SLOT_NOT_FOUND = "Không tìm thấy yêu cầu đổi ca làm việc";
            public const string SWAP_WORKING_SLOT_INVALID_WORKING_DATE = "Hai nhân viên có cùng ngày làm việc và cùng ca làm việc";
            public const string SWAP_WORKING_SLOT_INVALID_STATE = "Không thể từ chối yêu cầu không ở trạng thái chờ duyệt";
        }

        public class ConfigErrorConstant
        {
            public const string CONFIG_NOT_FOUND = "Không tìm thấy cấu hình";
            public const string CONFIG_INVALID = "Cấu hình không hợp lệ";
        }

        public class RoleErrorConstant
        {
            public const string ROLE_NOT_FOUND = "Không tìm thấy vai trò nhân viên";
        }

        public class WorkingSlotErrorConstant
        {
            public const string WORKING_SLOT_NOT_FOUND = "Không tìm thấy ca làm việc";
            public const string INVALID_WORKING_SLOT_SHIFT_TIME = "Thời gian bắt đầu ca phải sớm hơn thời gian kết thúc";
            public const string ALREADY_REGISTERED = "Nhân viên đã đăng ký ca làm việc này";
        }

        public class ShiftErrorConstant
        {
            public const string SHIFT_NOT_FOUND = "Không tìm thấy ca làm việc";
        }

        public class CurrentOrderIdExisted
        {
            public const string CURRENT_ORDER_ID_EXISTED = "Bàn đã có mã đơn hàng tồn tại";
        }

        public class ProductOptionErrorConstant
        {
            public const string PRODUCTOPTION_NOT_FOUND = "Không tìm thấy tùy chọn sản phẩm";
        }

        public class DayErrorConstant
        {
            public const string DAY_NOT_FOUND = "Không tìm thấy ngày trong tuần";
            public const string INVALID_DAY_OF_WEEK = "Ngày trong tuần không hợp lệ";
            public const string INVALID_START_DATE = "Ngày bắt đầu phải là ngày Thứ hai";
        }

        public class StaffScheduleErrorConstant
        {
            public const string STAFFSCHEDULE_NOT_FOUND = "Không tìm thấy lịch làm việc của nhân viên";
        }

        public class IngredientErrorConstant
        {
            public const string INGREDIENT_NOT_FOUND = "Không tìm thấy nguyên liệu";
        }

        public class StaffZoneScheduleErrorConstant
        {
            public const string STAFF_ZONE_SCHEDULE_NOT_FOUND = "Không tìm thấy lịch làm việc theo khu vực của nhân viên";
            public const string ZONE_ALREADY_ASSIGNED = "Nhân viên đã được phân vào khu vực này";
        }

        public class SizeErrorConstant
        {
            public const string SIZE_NOT_FOUND = "Không tìm thấy kích thước pizza";
        }

        public class BookingErrorConstant
        {
            public const string BOOKING_NOT_FOUND = "Không tìm thấy yêu cầu đặt chỗ";
            public const string BOOKING_SLOT_FULL = "Không còn bàn trống vào thời gian này";
            public const string INVALID_BOOKING_STATUS = "Trạng thái đặt chỗ không hợp lệ";
            public const string INVALID_BOOKING_CAPACITY = "Số lượng khách vượt quá sức chứa của bàn";
            public const string NOT_ASSIGNED_TABLE = "Bàn chưa được chỉ định";
        }

        public class BookingSlotErrorConstant
        {
            public const string BOOKING_SLOT_NOT_FOUND = "Khung giờ này không khả dụng để đặt chỗ";
        }

        public class OrderVoucherErrorConstant
        {
            public const string ORDERVOUCHER_NOT_FOUND = "Không tìm thấy voucher đơn hàng";
        }

        public class CategoryErrorConstant
        {
            public const string CATEGORY_NOT_FOUND = "Không tìm thấy danh mục món ăn";
        }

        public class ProductErrorConstant
        {
            public const string PRODUCT_NOT_FOUND = "Không tìm thấy món ăn";
            public const string INVALID_PRODUCT_TYPE = "Loại món ăn không hợp lệ";
            public const string INVALID_PRODUCT_OPTION = "Tùy chọn của món ăn không hợp lệ";
        }

        public class ProductSizeErrorConstant
        {
            public const string PRODUCTSIZE_NOT_FOUND = "Không tìm thấy kích thước món ăn";
            public const string PRODUCTSIZE_EXISTED = "Kích thước món ăn đã tồn tại";
        }

        public class RecipeErrorConstant
        {
            public const string RECIPE_NOT_FOUND = "Không tìm thấy công thức";
            public const string RECIPE_NOT_INCLUDED_INGREDIENT = "Công thức phải bao gồm ID hoặc tên nguyên liệu";
            public const string RECIPE_UNIT_INVALID = "Đơn vị đo lường không hợp lệ";
        }

        public class OrderItemErrorConstant
        {
            public const string INVALID_ORDER_ITEM_STATUS = "Trạng thái món trong đơn hàng không hợp lệ";
            public const string ORDER_ITEM_CANNOT_DONE = "Không thể hoàn thành món trong đơn hàng";
            public const string ORDER_ITEM_CANNOT_SERVED = "Không thể phục vụ món trong đơn hàng";
            public const string ORDER_ITEM_NOT_FOUND = "Không tìm thấy món trong đơn hàng";
        }

        public class OrderItemDetailErrorConstant
        {
            public const string ORDER_ITEM_DETAIL_NOT_FOUND = "Không tìm thấy chi tiết món ăn trong đơn hàng";
        }

        public class OptionItemErrorConstant
        {
            public const string OPTION_ITEM_NOT_FOUND = "Không tìm thấy tùy chọn món";
        }

        public class PaymentErrorConstant
        {
            public const string PAYMENT_NOT_FOUND = "Không tìm thấy thanh toán";
        }

        public class CustomerErrorConstant
        {
            public const string CUSTOMER_NOT_FOUND = "Không tìm thấy khách hàng";
        }

        public class FeedbackErrorConstant
        {
            public const string FEEDBACK_NOT_FOUND = "Không tìm thấy phản hồi nhận xét";
        }

        public class OrderErrorConstant
        {
            public const string ORDER_NOT_FOUND = "Không tìm thấy đơn hàng";
            public const string ORDER_CANNOT_CHECK_OUT = "Đơn hàng đã được xuất hóa đơn hoặc đã thanh toán";
            public const string ORDER_CANNOT_CANCEL_CHECK_OUT = "Đơn hàng chưa được xuất hóa đơn hoặc thanh toán";
            public const string ORDER_CANNOT_PAY = "Đơn hàng chưa được kiểm tra hoặc đã thanh toán";
            public const string ORDER_STATUS_INVALID_TO_ORDER = "Đơn hàng đã được xuất hóa đơn hoặc đã thanh toán";
        }

        public class StaffErrorConstant
        {
            public const string STAFF_NOT_FOUND = "Không tìm thấy nhân viên";
            public const string INVALID_STAFF_STATUS = "Trạng thái nhân viên không hợp lệ";
            public const string INVALID_STAFF_TYPE = "Loại nhân viên không hợp lệ";
        }

        public class OptionErrorConstant
        {
            public const string OPTION_NOT_FOUND = "Không tìm thấy tùy chọn món ăn";
        }

        public class StaffZoneErrorConstant
        {
            public const string STAFFZONE_NOT_FOUND = "Không tìm thấy nhân viên trong khu vực theo thời gian thực";
        }

        public class TableErrorConstant
        {
            public const string TABLE_NOT_FOUND = "Không tìm thấy bàn";
            public const string TABLE_NOT_HAVE_ORDER = "Bàn không có đơn hàng nào";
            public const string TABLE_ORDER_NOT_HAVE_ORDER_ITEM = "Đơn hàng không có món nào";
            public const string INVALID_TABLE_STATUS = "Trạng thái bàn không hợp lệ";
            public const string TABLE_ORDER_NOT_HAVE_TOTAL_PRICE = "Tổng tiền đơn hàng chưa được tính";
            public const string CAPACITY_INVALID = "Sức chứa bàn phải lớn hơn 0";
        }

        public class VoucherErrorConstant
        {
            public const string VOUCHER_NOT_FOUND = "Không tìm thấy voucher";
        }

        public class VoucherBatchErrorConstant
        {
            public const string TOTAL_QUANTITY_INVALID = "Số lượng tổng phải lớn hơn 0";
            public const string VOUCHER_TYPE_NOT_FOUND = "Không tìm thấy loại voucher";
            public const string VOUCHER_BATCH_INVALID_DISCOUNT_TYPE = "Không tìm thấy loại khuyến mãi";
        }

        public class ZoneErrorConstant
        {
            public const string ZONE_EXISTED = "Tên khu vực đã tồn tại";
            public const string ZONE_NOT_FOUND = "Không tìm thấy khu vực";
            public const string INVALID_ZONE_TYPE = "Khu vực không hợp lệ";
            public const string KITCHEN_ZONE_NOT_FOUND = "Không có khu vực bếp nào để gán đầu bếp";
            public const string DINING_ZONE_NOT_FOUND = "Không có khu vực ăn nào để gán nhân viên phục vụ";
        }
    }
}
