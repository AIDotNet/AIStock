using Volo.Abp.Application.Dtos;
using Yi.Framework.Bbs.Application.Contracts.Dtos.BbsUser;
using Yi.Framework.Bbs.Application.Contracts.Dtos.DiscussLable;
using Yi.Framework.Bbs.Application.Contracts.Dtos.Plate;
using Yi.Framework.Bbs.Domain.Shared.Consts;
using Yi.Framework.Bbs.Domain.Shared.Enums;
using Yi.Framework.Rbac.Application.Contracts.Dtos.User;

namespace Yi.Framework.Bbs.Application.Contracts.Dtos.Discuss
{
    public class DiscussGetOutputDto : EntityDto<Guid>
    {
        /// <summary>
        /// 是否禁止评论创建功能
        /// </summary>
        public bool IsDisableCreateComment { get; set; }
        public string Title { get; set; }
        public string? Introduction { get; set; }
        public int AgreeNum { get; set; }
        public int SeeNum { get; set; }
        public string Content { get; set; }
        public string? Color { get; set; }

        public Guid PlateId { get; set; }
        //是否置顶，默认false
        public bool IsTop { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        public string? Cover { get; set; }
        //是否私有，默认false
        public bool IsPrivate { get; set; }

        //私有需要判断code权限
        public string? PrivateCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DiscussPermissionTypeEnum PermissionType { get; set; }
        public bool IsAgree { get; set; } = false;
        public List<string> PermissionRoleCodes { get; set; } = new List<string>();
        
        
        
        public BbsUserGetListOutputDto User { get; set; }

        public PlateGetOutputDto Plate { get; set; }

        public List<Guid>? DiscussLableIds { get; set; } = new List<Guid>();
        public List<DiscussLableGetOutputDto> Lables { get; set; } =new List<DiscussLableGetOutputDto>();

        public bool HasPermission { get;internal set; }

        /// <summary>
        /// 设置权限
        /// </summary>
        public void SetPassPermission()
        {
            HasPermission = true;
        }
        /// <summary>
        /// 设置无权限
        /// </summary>
        public void SetNoPermission()
        {
            HasPermission = false;
            Content=DiscussConst.Privacy;
        }
    }
}
