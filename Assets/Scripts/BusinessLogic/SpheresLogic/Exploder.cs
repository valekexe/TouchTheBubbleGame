using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Exploder : IExploder
{
    private IOverlaper _overlaper;
    public Exploder(IOverlaper overlaper)
    {
        _overlaper = overlaper;
    }
    
    public async void Explode(float energy, EnergyReserver model)
    {
        var view = model.View;
        view.TirggeredCollider.isTrigger = false;
        var material = view.Renderer.material;

        Fade(view, material);
        _overlaper.Overlap(view.transform.localPosition, energy);
        CreateParticles(view, energy);
        
        await Task.Delay((int)(view.DestroyTime * 1000));
        ResetView(view);
        UnFade(material);
    }

    private void Fade(SphereView view, Material material)
    {
        DOTween.Sequence().SetEase(Ease.Flash).Append(material.DOFade(0, view.DestroyTime));
    }

    private void CreateParticles(SphereView view, float energy)
    {
        var constatntSpeed = view.Particles.main.startSpeed;
        constatntSpeed.constant *= energy;
        view.Particles.Play();
    }

    private void ResetView(SphereView view)
    {
        view.TirggeredCollider.isTrigger = true;
        view.gameObject.SetActive(false);
    }

    private void UnFade(Material material)
    {
        Color targetColor = new Color(material.color.r, material.color.g, material.color.b);
        material.color = targetColor;
    }
}