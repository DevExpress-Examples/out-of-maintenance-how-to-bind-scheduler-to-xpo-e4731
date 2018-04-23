public class XPResourceViewModel : BaseViewModel<XPResource> {
    public string Name { get; set; }

    public override void GetData(XPResource model) {
        model.Name = Name;
    }
}