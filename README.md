# Bug report for WinUI3 - CollectionViewSource does not include group items in AOT.

1- Run the project in Debug mode
2- Click "Add Item".
3- Observe the items are added to CollectionViewSource properly.
4- Run the project in Release mode (enables AOT)
5- Click "Add Item"
6- Observe the groups are created but the items do not belong to groups. Items are invisible.

## Notes

- ListView's prepare-clear container overrides are not triggered.
- CVS.View has DependencyObjects for CollectionGroups, but groups are empty.
- Setting HideIfEmpty on GroupStyle of ListView hides the groupes as well, making the CVS completely invisible.