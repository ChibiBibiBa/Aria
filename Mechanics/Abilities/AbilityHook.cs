namespace Aria.Mechanics.Abilities
{
    public delegate AbilityContext AbilityHook(AbilityContext context);
    public delegate DamagingAbilityContext DamagingAbilityHook(DamagingAbilityContext context);
    public delegate HealingAbilityContext HealingAbilityHook(HealingAbilityContext context);
    public delegate DefensiveAbilityContext DefensiveAbilityHook(DefensiveAbilityContext context);
}