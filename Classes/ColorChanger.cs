using UnityEngine;
using static silliness.Menu.Customization;

namespace silliness.Classes
{
    public class ColorChanger : TimedBehaviour
    {
        public override void Start()
        {
            base.Start();
            renderer = GetComponent<Renderer>();
            Update();
        }

        public override void Update()
        {
            base.Update();
            if (EToH == true)
            {
                thingy = 3f;
            }
            if (colorInfo != null)
            {
                if (!colorInfo.copyRigColors)
                {
                    Color color = new Gradient { colorKeys = colorInfo.colors }.Evaluate(Time.time / thingy % 1);
                    if (colorInfo.isRainbow)
                    {
                        float h = Time.frameCount / 180f % 1f;
                        color = Color.HSVToRGB(h, 1f, 1f);
                    }
                    renderer.material.color = color;
                }
                else
                {
                    renderer.material = GorillaTagger.Instance.offlineVRRig.mainSkin.material;
                }
            }
        }

        public Renderer renderer;
        public ExtGradient colorInfo;
        public float thingy = 2f;
    }
}
